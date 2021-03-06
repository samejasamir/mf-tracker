package com.mftracker.implementation;

import com.mftracker.Launcher;
import com.mftracker.interfaces.IAmcNavDAO;
import com.mftracker.interfaces.ISyncLatestNAV;

import java.awt.List;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.net.MalformedURLException;
import java.net.URL;
import java.nio.*;
import java.nio.channels.Channels;
import java.nio.channels.ReadableByteChannel;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.sql.Date;
import java.sql.SQLException;
import java.text.SimpleDateFormat;

import org.apache.log4j.Logger;


public class SyncLatestNAV implements ISyncLatestNAV {
	
	private static Logger logger=Logger.getLogger(SyncLatestNAV.class);
	
	private IAmcNavDAO dao=null;
	
	public SyncLatestNAV() {
		// TODO Auto-generated constructor stub
	}
	
	public SyncLatestNAV(IAmcNavDAO dao) {
		this.dao = dao;
	}

	@Override
	public void Sync() 
	{
		//METRICS INFO
		java.util.Date startTime = new java.util.Date();
		
		try
		{			
			java.util.List<String> output = GetLatestNAVFromAMFII();
			UpdateNAVs(output);
		}
		catch (Exception ex)
		{
			logger.fatal(ex);
		}		
		finally
		{
			long diff = ((new java.util.Date()).getTime() - startTime.getTime());
			logger.info("COMPLETED SYNC IN " + diff + " MILLISECONDS");
		}
	}
	
	private java.util.List<String> GetLatestNAVFromAMFII()
	{
		URL websiteUrl=null;
		try {
			websiteUrl = new URL("https://www.amfiindia.com/spages/NAVAll.txt");
			ReadableByteChannel rbc =  Channels.newChannel(websiteUrl.openStream());
			
			FileOutputStream fos = null;
			try
			{				
				fos = new FileOutputStream("latestnav");
				fos.getChannel().transferFrom(rbc, 0, Long.MAX_VALUE);				
			}
			finally
			{
				if(fos != null)
				{
					fos.flush();			
					fos.close();
				}
			}			
			
			return  Files.readAllLines(Paths.get("latestnav"));						
			
		} catch (Exception e) {
			logger.fatal(e);
			return null;
		}		
	}
	
	private void UpdateNAVs(java.util.List<String> listNavs) throws SQLException
	{
		String schemeType="";
		String amcName="";
		int amcId = 0;		
		
		listNavs.remove(0);
		
		try
		{
			dao.OpenConnection();
			for(String nav:listNavs)
			{	
				String[] columns = nav.split(";");
				if(columns.length == 1)
				{
					if(columns[0] != null && !columns[0].trim().isEmpty())
					{
						//COLLECTING SCHEME TYPE
						if(columns[0].contains("Schemes") && schemeType != columns[0])
						{
							schemeType = columns[0];
							logger.info(schemeType);
						}
						//INITIALIZING SCHEME NAME 
						else if(amcName != columns[0])
						{
							amcName = columns[0];
							amcId = dao.AddNewAMC(amcName);
							logger.info(amcId);
							logger.info(amcName);
						}
					}				
					
				}
				else
				{
					try
					{
						dao.AddNewNAV(amcId, columns[3], columns[1], columns[0], schemeType,new java.util.Date(),
								Double.parseDouble(columns[4]), Double.parseDouble(columns[5]), Double.parseDouble(columns[6]));
						
						logger.info(columns[3]);
					}
					catch(Exception ex)
					{
						logger.error("COULDNT ADD NAV FOR " + amcName + " " + columns + " " + ex.getMessage());
					}
				}
				
			}
		}
		finally		
		{
			dao.CloseConnection();			
		}
	}
	
}

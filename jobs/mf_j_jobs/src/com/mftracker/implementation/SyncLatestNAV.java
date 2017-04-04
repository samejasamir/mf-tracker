package com.mftracker.implementation;

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


public class SyncLatestNAV implements ISyncLatestNAV {

	@Override
	public void Sync()
	{
		java.util.List<String> output = GetLatestNAVFromAMFII();
		UpdateNAVs(output);
		//System.out.println(output);
	}
	
	private java.util.List<String> GetLatestNAVFromAMFII()
	{
		URL websiteUrl=null;
		try {
			websiteUrl = new URL("https://www.amfiindia.com/spages/NAVAll.txt");
			ReadableByteChannel rbc =  Channels.newChannel(websiteUrl.openStream());
			FileOutputStream fos = new FileOutputStream("latestnav");
			fos.getChannel().transferFrom(rbc, 0, Long.MAX_VALUE);
			return  Files.readAllLines(Paths.get("latestnav"));						
			
		} catch (Exception e) {
			e.printStackTrace();
			return null;
		}		
	}
	
	private void UpdateNAVs(java.util.List<String> listNavs)
	{
		String schemeType="";
		String schemeName="";
		
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
						System.out.println(schemeType);
					}
					//INITIALIZING SCHEME NAME 
					else if(schemeName != columns[0])
					{
						schemeName = columns[0];
						System.out.println(schemeName);
					}
				}				
				
			}
			else
			{
				//CALL DAO
			}
			
		}		
	}
	
}

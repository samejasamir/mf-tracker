package com.mftracker;

import java.io.IOException;
import javax.swing.text.AbstractDocument.Content;
import org.apache.log4j.Logger;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import com.mftracker.implementation.*;
import com.mftracker.interfaces.*;


public class Launcher {
	
	private static Logger logger=Logger.getLogger(Launcher.class);

	public static void main(String[] args) {
		
		try		
		{			
			ApplicationContext context = new ClassPathXmlApplicationContext("Beans.xml");
			ISyncLatestNAV obj = context.getBean(SyncLatestNAV.class);
			obj.Sync();
		}
		catch(Exception e)
		{
			logger.fatal(e);
		}
	}

}

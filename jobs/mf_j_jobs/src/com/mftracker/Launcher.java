package com.mftracker;

import java.io.IOException;

import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import com.mftracker.implementation.*;
import com.mftracker.interfaces.ISyncLatestNAV;

public class Launcher {

	public static void main(String[] args) {

		ApplicationContext context = new ClassPathXmlApplicationContext("Beans.xml");
		ISyncLatestNAV obj = context.getBean(SyncLatestNAV.class);
		obj.Sync();
		
		try {
			Object x = System.in.read();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

}

package com.mftracker.interfaces;

import java.sql.Connection;
import java.sql.Date;
import java.sql.SQLException;

public interface IAmcNavDAO {
	
	public int AddNewAMC(String amc_name) throws SQLException;
	
	public void AddNewNAV(int amc_id, String schemeName, String schemeISIN, String schemeCode, String schemeType, java.util.Date navDated, double navPrice, double navRepurchacePrice, double navSalesPrice) throws SQLException;
	
	public Connection OpenConnection();
	
	public void CloseConnection();
}

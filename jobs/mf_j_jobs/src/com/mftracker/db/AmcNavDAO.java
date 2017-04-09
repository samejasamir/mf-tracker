package com.mftracker.db;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.Date;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.List;

import org.apache.log4j.Logger;
import org.springframework.jdbc.datasource.DriverManagerDataSource;

import com.mftracker.interfaces.IAmcNavDAO;

public class AmcNavDAO implements IAmcNavDAO {
	
	private static Logger logger=Logger.getLogger(AmcNavDAO.class);

	private DriverManagerDataSource dataSource=null;
	private Connection connection=null;
	
	public AmcNavDAO(DriverManagerDataSource dataSource) {		
		this.dataSource = dataSource;
	}
	
	public Connection OpenConnection()	
	{
		try {
			this.connection = dataSource.getConnection();
			return this.connection;
		} catch (SQLException e) {
			logger.error(e);
		}
		return null;
	}
	
	public void CloseConnection()
	{
		try {
			if(this.connection != null && !this.connection.isClosed())
				this.connection.close();
		} catch (SQLException e) {
			logger.error(e);
		}
	}

	@Override
	public int AddNewAMC(String amc_name) throws SQLException {
		
		CallableStatement callableStatement = connection.prepareCall("call AddAMC(?)");
		callableStatement.setString(1, amc_name);
		ResultSet result = callableStatement.executeQuery();
		result.next();
		return result.getInt(1);		
	}


	@Override
	public void AddNewNAV(int amc_id, String schemeName, String schemeISIN, String schemeCode, String schemeType,
			java.util.Date navDated, double navPrice, double navRepurchacePrice, double navSalesPrice) throws SQLException {
		CallableStatement callableStatement = connection.prepareCall("call AddNAV(?,?,?,?,?,?,?,?,?)");
		callableStatement.setInt(1, amc_id);
		callableStatement.setString(2, schemeName);
		callableStatement.setString(3, schemeISIN);
		callableStatement.setString(4, schemeCode);
		callableStatement.setString(5, schemeType);
		callableStatement.setDate(6, new java.sql.Date(navDated.getTime()));
		callableStatement.setDouble(7, navPrice);
		callableStatement.setDouble(8, navRepurchacePrice);
		callableStatement.setDouble(9, navSalesPrice);		
		callableStatement.executeUpdate();
	}

}

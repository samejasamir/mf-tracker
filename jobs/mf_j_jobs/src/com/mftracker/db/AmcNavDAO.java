package com.mftracker.db;

import java.util.List;

import org.springframework.jdbc.core.JdbcTemplate;

import com.mftracker.interfaces.IAmcNavDAO;

public class AmcNavDAO implements IAmcNavDAO {
	
	private JdbcTemplate _jdbcTemplate=null;
	
	public AmcNavDAO(JdbcTemplate jdbcTemplate) {
		_jdbcTemplate = jdbcTemplate;
	}

	@Override
	public void AddNewNAV(List<String> nav) {
		
		String insertStatement = "";
	}

}

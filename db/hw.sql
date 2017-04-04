
CREATE TABLE mf_tracker.`amc` (
  `amc_id` int(11) NOT NULL,
  `amc_name` varchar(200) NOT NULL,
  PRIMARY KEY (`amc_id`)
);

create table mf_tracker.mutualfunds
(
		mf_id int not null,
        amc_id int,
        mf_name varchar(200) not null,
        primary key (mf_id),
        foreign key (amc_id) references amc(amc_id)               
);


create table mf_tracker.nav
(
	nav_id int not null,
    mf_id int,
    nav_date datetime,
    nav double,
    primary key (nav_id),
    foreign key (mf_id) references mutualfunds(mf_id)
);

create table mf_tracker.portfolio
(
	portfolio_id int,
    mf_id int,
    portfolio_number varchar(50),
    portfolio_date datetime,
    portfolio_amt double,
    portfolio_units double,
    primary key (portfolio_id),
    foreign key (mf_id) references mutualfunds(mf_id)
);

CREATE DEFINER=`root`@`localhost` PROCEDURE `AddAMC`(
	IN amc_name VARCHAR(200)
)
BEGIN
	DECLARE last_amc_index int;	
	SET last_amc_index = (SELECT amc_id FROM amc ORDER BY amc_id DESC LIMIT 1);
    select last_amc_index;
    IF (last_amc_index IS NULL) then 
		SET last_amc_index:=0; 
	END IF;
    select last_amc_index;
	INSERT INTO amc VALUES(last_amc_index+1,amc_name);	
END

CALL `mf_tracker`.`AddAMC`('SAMIR');
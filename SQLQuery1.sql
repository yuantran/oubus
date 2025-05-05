﻿CREATE TABLE users
(	
	id INT PRIMARY KEY IDENTITY(1,1),
	username VARCHAR(MAX) NULL,
	password VARCHAR(MAX) NULL,
	profile_image VARCHAR(MAX) NULL,
	role VARCHAR(MAX) NULL,
	status VARCHAR(MAX) NULL,
	date_reg DATE NULL,
)

SELECT * FROM users

INSERT INTO users (username, password, profile_image, role, status, date_reg) VALUES ('admin','admin123','','Admin','Active','2023-11-1')

CREATE TABLE products 
(
id INT PRIMARY KEY IDENTITY(1,1), 
prod_id VARCHAR(MAX) NULL, 
prod_name VARCHAR(MAX) NULL, 
prod_type VARCHAR(MAX) NULL, 
prod_stock INT NULL, 
prod_price FLOAT NULL, 
prod_status VARCHAR(MAX) NULL, 
prod_image VARCHAR(MAX) NULL, 
date_insert DATE NULL, 
date_update DATE NULL, 
date_delete DATE NULL 
)
SELECT FROM products
CREATE TABLE users
(	
	id INT PRIMARY KEY IDENTITY(1,1),
	username VARCHAR(MAX) NULL,
	password VARCHAR(MAX) NULL,
	profile_image VARBINARY(MAX) NULL,
	phone VARCHAR(MAX) NULL,
	role VARCHAR(MAX) NULL,
	mssv VARCHAR(MAX) NULL,
	date_reg DATE NULL,
)

SELECT * FROM users

INSERT INTO users (username, password, profile_image, phone, role, mssv, date_reg) VALUES ('admin','admin123','','0904111','Admin','','2023-11-1')

CREATE TABLE chuyenxe 
(
id INT PRIMARY KEY IDENTITY(1,1), 
chuyen_id VARCHAR(MAX) NULL, 
bien_so_xe VARCHAR(MAX) NULL, 
tuyen_xe VARCHAR(MAX) NULL, 
tai_xe VARCHAR(MAX) NULL, 
ca_chay VARCHAR(MAX) NULL, 
ngay_chay DATE NULL, 
taixe_image VARCHAR(MAX) NULL, 
date_insert DATE NULL, 
date_update DATE NULL, 
date_delete DATE NULL 
)

SELECT * FROM chuyenxe 

CREATE TABLE datve
(	
	id INT PRIMARY KEY IDENTITY(1,1),
	mssv VARCHAR(10) NULL,
	tuyen_xe VARCHAR(MAX) NULL,
	profile_image VARBINARY(MAX) NULL,
	phone VARCHAR(10) NULL,
	ngay_di DATE NULL,
	di_sang BIT NULL,
	di_trua BIT NULL,
	ve_trua BIT NULL,
	ve_chieu BIT NULL
)
SELECT * FROM datve

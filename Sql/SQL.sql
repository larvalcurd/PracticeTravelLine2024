IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Rooms')
	CREATE TABLE dbo.Rooms (
		room_id INT IDENTITY(1, 1) NOT NULL,
		room_number INT NOT NULL,
		room_type NVARCHAR(50) NOT NULL,
		price_per_night INT NOT NULL,
		availability NVARCHAR(50) NOT NULL,
		CONSTRAINT PK_Rooms_room_id PRIMARY KEY (room_id)		
	);
	
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Customers')
  CREATE TABLE dbo.Customers (
    customer_id INT IDENTITY(1, 1) NOT NULL,
    first_name NVARCHAR(50) NOT NULL,
    last_name NVARCHAR(50) NOT NULL,
    email NVARCHAR(50) NOT NULL,
    phone_number NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_Customer_customer_id PRIMARY KEY (customer_id)
  );
  
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Bookings')
  CREATE TABLE dbo.Bookings (
    booking_id INT IDENTITY(1, 1) NOT NULL,
    customer_id INT NOT NULL,
    room_id INT NOT NULL,
    check_in_date DATE NOT NULL,
    check_out_date DATE NOT NULL,
    CONSTRAINT PK_Bookings_booking_id PRIMARY KEY (booking_id),
    
    CONSTRAINT FK_Bookings_customer_id 
      FOREIGN KEY (customer_id) REFERENCES dbo.Customers (customer_id),
      
    CONSTRAINT FK_Bookings_room_id
      FOREIGN KEY (room_id) REFERENCES dbo.Rooms (room_id)
  );
  
  IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Facilities')
	  CREATE TABLE dbo.Facilities (
  		facility_id INT IDENTITY(1, 1) NOT NULL,
  		facility_name NVARCHAR(100) NOT NULL,		
  		CONSTRAINT PK_Facilities_facility_id PRIMARY KEY (facility_id)
	);
	
	IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'RoomsToFacilities')
	  CREATE TABLE dbo.RoomsToFacilities(
	    room_id INT NOT NULL,
	    facility_id INT NOT NULL,
	    
	    CONSTRAINT FK_RoomsToFacilities_facility_id
	      FOREIGN KEY (facility_id) REFERENCES dbo.Facilities (facility_id),
	    CONSTRAINT FK_RoomsToFacilities_room_id
	      FOREIGN KEY (room_id) REFERENCES dbo.Rooms (room_id),
	);
	
	INSERT INTO dbo.Facilities VALUES
	  ('WI-FI'),
	  ('Air conditioner'),
	  ('TV'),
	  ('Safe'),
	  ('Mini bar'),
	  ('Telephone'),
	  ('Shower');
	  
	
INSERT INTO dbo.Rooms VALUES
	(12, 'single', 2000, 'free'),
	(13, 'double', 3000, 'busy'),
	(14, 'single', 2000, 'busy'),
	(15, 'double', 3000, 'free'),
	(16, 'family', 5000, 'free');
	
INSERT INTO dbo.Customers VALUES
  ('Ivan', 'Berezin', 'berezin.ivan@email.com', '79367778886'),
  ('Anton', 'Kozlov', 'anton.kozlov@gmail.com', '79027398543'),
  ('Maxim', 'Romanov', 'maxim.romanov@email.com', '79061396565'),
  ('Platon', 'Yeschapskii', 'ohioswag@richmail.com', '77777777777'),
  ('Pavel', 'Severin', 'pasha@spacemail.com', '79877282676');
  
INSERT INTO dbo.Bookings VALUES
  (1, 3, '2024-07-02', '2024-07-09'),
  (2, 2, '2024-07-02', '2024-07-09'),
  (3, 2, '2024-07-02', '2024-07-09');
  
INSERT INTO dbo.RoomsToFacilities VALUES
  (1, 1),
  (1, 2),
  (1, 7),
  (2, 1),
  (2, 2),
  (2, 3),
  (2, 4),
  (2, 6),
  (2, 7),
  (3, 1),
  (3, 2),
  (3, 7),
  (4, 1),
  (4, 2),
  (4, 3),
  (4, 4),
  (4, 6),
  (4, 7),
  (5, 1),
  (5, 2),
  (5, 3),
  (5, 4),
  (5, 5),
  (5, 6),
  (5, 7);
  
SELECT * FROM Rooms WHERE availability = 'free'
  
SELECT * FROM dbo.Customers WHERE last_name LIKE 'S%'

SELECT * FROM dbo.bookings
JOIN dbo.customers ON bookings.customer_id = customers.customer_id
WHERE customers.email = 'berezin.ivan@email.com';

SELECT * FROM dbo.bookings
JOIN dbo.rooms ON bookings.room_id = rooms.room_id
WHERE rooms.room_number = '13';


SELECT * FROM rooms as r
WHERE r.availability = 'free' AND r.room_id NOT IN (
	SELECT b.room_id FROM bookings as b
	WHERE '2024-07-11' BETWEEN b.check_in_date AND b.check_out_date
);


  
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
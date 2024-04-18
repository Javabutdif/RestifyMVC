CREATE DATABASE Restify;

USE Restify

CREATE TABLE Landlord (
    landlord_id INT PRIMARY KEY IDENTITY,
    landlord_first_name NVARCHAR(50) NOT NULL,
    landlord_last_name NVARCHAR(50) NOT NULL,
    landlord_email NVARCHAR(100) NOT NULL,
    landlord_contact NVARCHAR(20) NOT NULL,
    landlord_password NVARCHAR(50) NOT NULL
);

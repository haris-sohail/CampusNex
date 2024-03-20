DROP DATABASE IF EXISTS CampusNex;
CREATE DATABASE CampusNex;
USE CampusNex;

/*
		  CREATE TABLE
*/

-- Users Table

CREATE TABLE Users (
    user_id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    role ENUM('student', 'mentor') NOT NULL
);

-- Students Table
CREATE TABLE Students (
    student_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT NOT NULL,
    roll_number VARCHAR(20) UNIQUE NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

-- Mentor ID
CREATE TABLE Mentors (
    mentor_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT NOT NULL,
    designation VARCHAR(100) NOT NULL,
    education_info TEXT,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);



-- Societies Table

CREATE TABLE Societies (
    society_id INT PRIMARY KEY AUTO_INCREMENT,
    society_name VARCHAR(100) UNIQUE NOT NULL,
    society_description TEXT,
    mentor_id INT NOT NULL,
	head_id INT NOT NULL,
    creation_date DATE NOT NULL,
    FOREIGN KEY (head_id) REFERENCES Students(student_id),
    FOREIGN KEY (mentor_id) REFERENCES Users(user_id)
);

-- Event Table
CREATE TABLE Events (
    event_id INT PRIMARY KEY AUTO_INCREMENT,
    society_id INT NOT NULL,
    title VARCHAR(100) NOT NULL,
    event_date DATE NOT NULL,
    event_time TIME NOT NULL,
    location VARCHAR(255) NOT NULL,
    description TEXT,
    event_type VARCHAR(50) NOT NULL,
    organizer_id INT NOT NULL,
    FOREIGN KEY (society_id) REFERENCES Societies(society_id),
    FOREIGN KEY (organizer_id) REFERENCES Students(student_id)
);


-- Members Table

CREATE TABLE Members (
    member_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT NOT NULL,
    society_id INT NOT NULL,
    join_date DATE NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (society_id) REFERENCES Societies(society_id)
);




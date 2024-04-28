Use master;
DROP DATABASE IF EXISTS CampusNex;
CREATE DATABASE CampusNex;
USE CampusNex;

/*
		  CREATE TABLE
*/

use CampusNex;
--Drop database CampusNex;
CREATE TABLE CUsers (
    user_id INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
	role NVARCHAR(50) NOT NULL CHECK (role IN ('student', 'mentor')), 
    user_pic image
);

-- Students Table
CREATE TABLE Students (
    student_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT NOT NULL,
    roll_number VARCHAR(20) UNIQUE NOT NULL,
    FOREIGN KEY (user_id) REFERENCES CUsers(user_id)
);

-- Mentor ID
CREATE TABLE Mentors (
    mentor_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT NOT NULL,
    designation VARCHAR(100) NOT NULL,
    education_info TEXT,
    FOREIGN KEY (user_id) REFERENCES CUsers(user_id)
);



-- Societies Table

CREATE TABLE Societies (
    society_id INT PRIMARY KEY IDENTITY(1,1),
    society_name VARCHAR(100) UNIQUE NOT NULL,
    society_slogan VARCHAR(100) NOT NULL,
    society_description nvarchar(max),
    mentor_id INT NOT NULL,
	head_id INT NOT NULL,
    creation_date DATE NOT NULL,
    society_logo image,
	status NVARCHAR(50) CHECK (status IN ('pending', 'accepted', 'rejected')) NOT NULL,
	comments VARCHAR(200),
    FOREIGN KEY (head_id) REFERENCES Students(student_id),
    FOREIGN KEY (mentor_id) REFERENCES Mentors(mentor_id)
);
-- Society Reg Request


-- Event Table
CREATE TABLE Events (
    event_id INT PRIMARY KEY IDENTITY(1,1),
    society_id INT NOT NULL,
    title VARCHAR(100) NOT NULL,
    event_date DATE NOT NULL,
    event_time TIME NOT NULL,
    location VARCHAR(255) NOT NULL,
    description nvarchar(max),
    event_type VARCHAR(50) NOT NULL,
    organizer_id INT NOT NULL,
	status NVARCHAR(50) CHECK (status IN ('pending', 'accepted', 'rejected')) NOT NULL,
    event_Img image,
	comments VARCHAR(200), 
    FOREIGN KEY (society_id) REFERENCES Societies(society_id),
    FOREIGN KEY (organizer_id) REFERENCES Students(student_id)
);

-- Members Table

CREATE TABLE Members (
    member_id INT PRIMARY KEY IDENTITY(1,1),
    student_id INT NOT NULL,
    society_id INT NOT NULL,
    join_date DATE NOT NULL,
    is_head BIT NOT NULL,
    interest VARCHAR(200),   
    status NVARCHAR(50) CHECK (status IN ('pending', 'accepted', 'rejected')) NOT NULL,
    FOREIGN KEY (student_id) REFERENCES Students(student_id),
    FOREIGN KEY (society_id) REFERENCES Societies(society_id)
);

-- Announcements table

CREATE TABLE Announcements (
	announcement_id INT PRIMARY KEY IDENTITY(1,1),
    head_id INT NOT NULL,
    society_id INT NOT NULL,
    title VARCHAR(100) NOT NULL,
    body VARCHAR(300) NOT NULL,
    posted_at DATETIME NOT NULL,
    valid_till DATETIME NOT NULL,
	priority NVARCHAR(50) CHECK (priority IN ('low', 'medium', 'high')) NOT NULL,
    FOREIGN KEY (head_id) REFERENCES Students(student_id),
    FOREIGN KEY (society_id) REFERENCES Societies(society_id)
);

INSERT INTO CUsers (username, password, email, role, user_pic) VALUES
('kalsoom', 'password', 'kalsoom@gmail.com', 'student',(SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\5.png', SINGLE_BLOB) AS user_pic)),
('haris', 'password', 'haris@gmail.com', 'mentor', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\1.png', SINGLE_BLOB) AS user_pic)),
('aiman', 'password', 'aiman@gmail.com', 'mentor', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\6.png', SINGLE_BLOB) AS user_pic)),
('aliza', 'password', 'aliza@gmail.com', 'student', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\4.png', SINGLE_BLOB) AS user_pic)),
('kissa', 'password', 'kissa@gmail.com', 'student', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\2.png', SINGLE_BLOB) AS user_pic)),
('hamna', 'password', 'hamna@gmail.com', 'student', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\3.png', SINGLE_BLOB) AS user_pic)),
('test', 'password', 'test@gmail.com', 'student', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\5.png', SINGLE_BLOB) AS user_pic)),
('kalsoomtariq', 'Password', 'kalsoomtariq@gmail.com', 'student', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\5.png', SINGLE_BLOB) AS user_pic)),
('masood', 'password', 'masood@gmail.com', 'student', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\5.png', SINGLE_BLOB) AS user_pic)),
('dilshankhatoon', 'password', 'dilshan@gmail.com', 'student', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\5.png', SINGLE_BLOB) AS user_pic)),
('khurramshehzzad', 'password', 'khurram@gmail.com', 'student', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\5.png', SINGLE_BLOB) AS user_pic)),
('abubakarmukarram', 'password', 'abubakar@gmail.com', 'student', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\5.png', SINGLE_BLOB) AS user_pic)),
('ahmed', 'passw', 'ahmed@gmail.com', 'student', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\5.png', SINGLE_BLOB) AS user_pic)),
('mukarram', 'passwo', 'mukkarram@gmail.com', 'student', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\5.png', SINGLE_BLOB) AS user_pic)),
('siddique', 'passwordpassword1', 'siddique@gmail.com', 'student', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\5.png', SINGLE_BLOB) AS user_pic)),
('zainulabideen', 'passwordpassword12', 'zain@gmail.com', 'student', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\5.png', SINGLE_BLOB) AS user_pic)),
('musaamir', 'passwordpassword123', 'musa@gmail.com', 'student', (SELECT BULKCOLUMN FROM OPENROWSET(BULK 'D:\\SOMAL\\SEMESTER_06\\Software Engineering\\Project\\5.png', SINGLE_BLOB) AS user_pic));

INSERT INTO Students (user_id, roll_number) VALUES
(1, 2487),
(4, 470),
(5, 572),
(6, 603),
(7, 111);

INSERT INTO Mentors (user_id, designation, education_info) VALUES
(2, 'Assistant Professor', 'BSCS'),
(3, 'Assistant Professor', 'BSCS')
;

INSERT INTO Societies (society_name, society_slogan, society_description, mentor_id, head_id, creation_date, society_logo, status)
VALUES
('Fast Computing Society', 'Computer Computer Computer' ,'The Fast Computing Society is a student organization dedicated to promoting and advancing knowledge, skills, and innovation in the field of computing through various educational, collaborative, and networking activities.', 1, 1, '2012-05-15', (SELECT BulkColumn FROM OPENROWSET(BULK 'D:\SOMAL\SEMESTER_06\Software Engineering\Project\FCS_Logo.png', SINGLE_BLOB) AS society_logo), 'accepted'),
('Fast Data Science Society', 'Data, Data Everywhere' ,'FDSS is a student organization dedicated to promoting and advancing knowledge, skills, and innovation in the field of computing through various educational, collaborative, and networking activities.', 1, 2, '2012-05-15', (SELECT BulkColumn FROM OPENROWSET(BULK 'D:\SOMAL\SEMESTER_06\Software Engineering\Project\FDSS_Logo.png', SINGLE_BLOB) AS society_logo), 'accepted'),
('Robotics Society', 'Building the Future', 'The Robotics Society aims to explore the intersection of technology and robotics to create innovative solutions for real-world problems.', 1, 3, '2024-04-16', (SELECT BulkColumn FROM OPENROWSET(BULK 'D:\SOMAL\SEMESTER_06\Software Engineering\Project\RS_Logo.png', SINGLE_BLOB) AS society_logo), 'pending'),
('AI Enthusiasts Society', 'Exploring the Future of AI', 'The AI Enthusiasts Society is dedicated to exploring the latest advancements and applications of artificial intelligence.', 1, 4, '2024-04-16', (SELECT BulkColumn FROM OPENROWSET(BULK 'D:\SOMAL\SEMESTER_06\Software Engineering\Project\AI_Logo.png', SINGLE_BLOB) AS society_logo), 'pending'),
('Cybersecurity Alliance', 'Securing the Digital World', 'The Cybersecurity Alliance focuses on raising awareness and providing resources to address cybersecurity challenges.', 1, 5, '2024-04-17', (SELECT BulkColumn FROM OPENROWSET(BULK 'D:\SOMAL\SEMESTER_06\Software Engineering\Project\CS_Logo.png', SINGLE_BLOB) AS society_logo), 'pending');

 
INSERT INTO Members (student_id, society_id, join_date, is_head, interest,status)
VALUES (1, 1, '2023-05-20', 1, 'Computing, Artificial Intelligence','accepted'),
(2, 2, '2023-01-20', 1, 'Data Science, Machine Learning','accepted'),
(3, 1, '2024-01-10', 0, 'Graphic Design, Calculations','accepted'),
(4, 2, '2024-02-05', 0, 'NLP, Management','pending'),
(3, 3, '2024-02-05', 1, 'NLP, Management','pending'),
(4, 4, '2024-02-05', 1, 'NLP, Management','pending'),
(5, 5, '2024-02-05', 1, 'NLP, Management','pending');

INSERT INTO Events (society_id, title, event_date, event_time, location, description, event_type, organizer_id, status, event_Img)
VALUES 
(2, 'Data Escapes', '2024-04-15', '15:00:00', 'Community Hall', 'Join us for an immersive journey into the world of data science at "Data Escapes." This captivating event brings together data enthusiasts, experts, and novices alike to explore the endless possibilities and applications of data science.', 'Seminar', 2, 'accepted', (SELECT BulkColumn FROM OPENROWSET(BULK 'D:\SOMAL\SEMESTER_06\Software Engineering\Project\DataEscape.png', SINGLE_BLOB) AS event_Img)),
(1, 'Code Craft', '2024-06-15', '12:30:00', 'Khyber Lab II', 'Join us for an exhilarating coding workshop hosted by the Computing Society, where we delve into the intricacies of software development, algorithmic problem-solving, and innovative coding techniques', 'Workshop', 3, 'pending', (SELECT BulkColumn FROM OPENROWSET(BULK 'D:\SOMAL\SEMESTER_06\Software Engineering\Project\CodeCraft.png', SINGLE_BLOB) AS event_Img));


 -- The following query runs on Haris' machine only
 
 -- INSERT INTO Societies (society_name, society_slogan,society_description, mentor_id, head_id, creation_date,society_logo) VALUES
-- ('Fast Computing Society', 'Computer Computer Computer' ,'The Fast Computing Society is a student organization dedicated to promoting and advancing knowledge,
-- skills, and innovation in the field of computing through various educational, 
-- collaborative, and networking activities.', 2, 1, '2012-05-15',(LOAD_FILE('F:\\Haris\'\\Assignments\\SE_Iteration0\\CampusNex\\Project_Description\\assets\\AceCodersLogo.png')));

-- UPDATE Societies
-- SET society_logo = LOAD_FILE('ab.jpg')
-- WHERE society_id = 1;


-- aimen's machine
-- INSERT INTO Societies (society_name, society_slogan,society_description, mentor_id, head_id, creation_date,society_logo,status) VALUES
-- ('Fast Computing Society', 'Computer Computer Computer' ,'The Fast Computing Society is a student organization dedicated to promoting and advancing knowledge,
-- skills, and innovation in the field of computing through various educational, 
-- collaborative, and networking activities.', 1, 1, '2012-05-15',(LOAD_FILE('C:\\CUsers\\aimen\\Desktop\\SE\\Project\\CampusNex\\Project_Description\\assets\\AceCodersLogo.png')),'accepted'),
-- ('Fast Data Science Society', 'Data, Data Everywhere' ,'FDSS is a student organization dedicated to promoting and advancing knowledge,
-- skills, and innovation in the field of computing through various educational, 
-- collaborative, and networking activities.', 1, 2, '2012-05-15',(LOAD_FILE('C:\\CUsers\\aimen\\Desktop\\SE\\Project\\CampusNex\\Project_Description\\assets\\AceCodersLogo.png')),'pending');


 SELECT * FROM Societies;
 
 SELECT * FROM CUsers;
 SELECT * FROM Students;
 SELECT * FROM Mentors where user_id = 2;
 
 SELECT * FROM Members;
 
  select username from CUsers INNER JOIN Students ON Students.user_id = CUsers.user_id WHERE Students.user_id = 1;

-- Select Mentors Avaiable based on no enlistment
SELECT U.username AS mentor_name
FROM Mentors M
INNER JOIN CUsers U ON M.user_id = U.user_id
LEFT JOIN Societies S ON M.mentor_id = S.mentor_id
WHERE S.society_id IS NULL
AND U.role = 'mentor';

-- Select Mentors Avaiable based on less than 2 societies
SELECT U.username AS mentor_name-- , COUNT(S.society_id) AS num_societies_enlisted
FROM Mentors M
INNER JOIN CUsers U ON M.user_id = U.user_id
LEFT JOIN Societies S ON M.mentor_id = S.mentor_id
WHERE U.role = 'mentor'
GROUP BY M.mentor_id,U.username
HAVING COUNT(S.society_id) < 2;

select * from Societies;
select * from Members;
select society_name, u.username from societies s join students st on s.head_id = st.student_id
join CUsers u on st.user_id = u.user_id where s.status = 'pending' and mentor_id = 1;

select * from members;

SELECT U.user_pic AS user_img, U.username AS user_name, S.society_name
FROM Members M
JOIN Students St ON M.student_id = St.student_id
JOIN CUsers U ON St.user_id = U.user_id
JOIN Societies S ON M.society_id = S.society_id
WHERE M.status = 'pending' and M.society_id = 2;

-- show variables like "secure_file_priv";

SELECT user_id, role, username FROM CUsers WHERE CUsers.username = 'haris' AND CUsers.password = 'password';

select * from societies;
DROP DATABASE IF EXISTS PRN211_Online_English_Quiz;
CREATE DATABASE PRN211_Online_English_Quiz;

USE PRN211_Online_English_Quiz;

CREATE TABLE [User] (
	username VARCHAR(255) PRIMARY KEY,
	[password] VARCHAR(255),
	displayName NVARCHAR(255),
	email VARCHAR(255),
	registrationDate DATE
)

CREATE TABLE [Role](
	roleId INT NOT NULL PRIMARY KEY,
	roleName VARCHAR(50)
)

CREATE TABLE UserRole(
	username VARCHAR(255) NOT NULL REFERENCES [User](username),
	roleId INT NOT NULL REFERENCES [Role](roleId)
	PRIMARY KEY (username, roleId)
)

CREATE TABLE Quiz(
	quizId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	quizTitle VARCHAR(255),
	quizDescription VARCHAR(max),
	created_by VARCHAR(255) REFERENCES [User](username),
	duration INT
)

CREATE TABLE UserQuiz(
	UserQuizId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	username VARCHAR(255) REFERENCES [User](username),
	quizId INT REFERENCES [Quiz](quizId),
	score DECIMAL(4,2),
	dateTaken DATE
)

CREATE TABLE Question (
	questionId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	questionText VARCHAR(255)
)

CREATE TABLE QuizQuestion(
	quizId INT REFERENCES [Quiz](quizId),
	questionId INT REFERENCES [Question](questionid)
)

CREATE TABLE Answer(
	answerId INT PRIMARY KEY NOT NULL IDENTITY(1,1) ,
	questionId INT REFERENCES Question(questionId),
	answerText VARCHAR(255),
	isCorrectAnswer BIT
)

USE [master]
GO
/****** Object:  Database [QuanLyThiTracNghiemOnline]    Script Date: 11/15/2017 6:53:05 PM ******/
CREATE DATABASE [QuanLyThiTracNghiemOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyThiTracNghiemOnline', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QuanLyThiTracNghiemOnline.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyThiTracNghiemOnline_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QuanLyThiTracNghiemOnline_log.ldf' , SIZE = 6400KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyThiTracNghiemOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuanLyThiTracNghiemOnline]
GO
/****** Object:  User [QUIZPRO]    Script Date: 11/15/2017 6:53:05 PM ******/
CREATE USER [QUIZPRO] FOR LOGIN [QUIZPRO] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [dbms]    Script Date: 11/15/2017 6:53:05 PM ******/
CREATE USER [dbms] FOR LOGIN [dbms] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [db_executor]    Script Date: 11/15/2017 6:53:05 PM ******/
CREATE ROLE [db_executor]
GO
ALTER ROLE [db_executor] ADD MEMBER [QUIZPRO]
GO
ALTER ROLE [db_owner] ADD MEMBER [dbms]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [dbms]
GO
ALTER ROLE [db_datareader] ADD MEMBER [dbms]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [dbms]
GO
/****** Object:  StoredProcedure [dbo].[PROC_addUser]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_addUser](@username varchar(20), @fullname NVARCHAR(50), @gender BIT, @birthday DATE, @roleid VARCHAR(20))
AS
BEGIN
	INSERT INTO dbo.USERS(Username,Fullname,Gender,Birthday,RoleID)  VALUES(@username,@fullname,@gender, @birthday, @roleiD)
END
GO
/****** Object:  StoredProcedure [dbo].[proc_changePwd]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   CREATE PROC [dbo].[proc_changePwd] @username varchar(20), @pwd VARCHAR(50)
   AS
   BEGIN
   	UPDATE dbo.USERS SET Password = @pwd WHERE Username = @username
   END
GO
/****** Object:  StoredProcedure [dbo].[proc_changeRole]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_changeRole] @username VARCHAR(20), @rolename NVARCHAR(50)
AS
BEGIN
	DECLARE @roleID VARCHAR(20)
	SELECT @roleID = dbo.ROLES.RoleID FROM dbo.ROLES WHERE RoleName = @rolename
	IF @roleID IS NOT NULL
	BEGIN
		UPDATE dbo.USERS SET RoleID = @roleID WHERE Username = @username
	END
END
GO
/****** Object:  StoredProcedure [dbo].[proc_deleteAnswer]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_deleteAnswer] @ansid VARCHAR(20) AS
BEGIN
	DELETE FROM dbo.ANSWER WHERE AnsID = @ansid
END
GO
/****** Object:  StoredProcedure [dbo].[proc_deleteClassExam]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_deleteClassExam] @classid VARCHAR(20), @examid VARCHAR(20) AS
BEGIN
	DELETE FROM dbo.CLASS_EXAM WHERE ClassID = @classid AND ExID= @examid
END
GO
/****** Object:  StoredProcedure [dbo].[proc_deleteExam]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_deleteExam] @examid VARCHAR(20) AS
BEGIN
	DELETE FROM dbo.EXAM WHERE ExID = @examid
END
GO
/****** Object:  StoredProcedure [dbo].[proc_deleteQues]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_deleteQues] @quesid VARCHAR(20) AS
BEGIN
	DELETE FROM dbo.QUESTION WHERE QuesID = @quesid
END
GO
/****** Object:  StoredProcedure [dbo].[proc_deleteQuesInExam]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_deleteQuesInExam] @quesid VARCHAR(20) AS
BEGIN
	DELETE FROM dbo.EXAM_QUES WHERE QuesID = @quesid
END
GO
/****** Object:  StoredProcedure [dbo].[proc_deleteTeacher]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_deleteTeacher] @username VARCHAR(20)
AS
BEGIN
	DELETE FROM dbo.TEACHER WHERE Teacher = @username
END
GO
/****** Object:  StoredProcedure [dbo].[proc_deleteUser]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_deleteUser](@username varchar(20))
AS
BEGIN
	DELETE FROM dbo.USERS WHERE Username = @username
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_editUser]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_editUser](@username varchar(20), @fullname NVARCHAR(50), @gender BIT, @birthday DATE)
AS
BEGIN
	UPDATE dbo.USERS SET Fullname = @fullname, Gender = @gender, Birthday = @birthday WHERE Username = @username
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_getAnswer]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_getAnswer](@quesid NVARCHAR(20))
AS
BEGIN
	SELECT dbo.ANSWER.AnsID, dbo.ANSWER.AnsContent, dbo.ANSWER.IsCorrect FROM dbo.ANSWER WHERE dbo.ANSWER.QuesID = @quesid;
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_getContent]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_getContent](@subid VARCHAR(20))
AS
BEGIN
	IF @subid IS NULL
	BEGIN
		SELECT TypeID, Typename FROM dbo.TYPEQUES
	END
	ELSE
	BEGIN
		SELECT dbo.TYPEQUES.TypeID,dbo.TYPEQUES.Typename FROM dbo.TYPEQUES WHERE dbo.TYPEQUES.SubID = @subid;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_getExamHistory]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_getExamHistory](@username NVARCHAR(20))
AS
BEGIN
	SELECT Exname,dbo.SUBJECTS.Subname, DateTest, Mark, TimeComplete FROM dbo.RESULT, dbo.EXAM, dbo.SUBJECTS WHERE EXAM.ExID = RESULT.ExID and Student = @username AND SubjectID=SubID
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_getQuestion]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_getQuestion](@examid NVARCHAR(20))
AS
BEGIN
	SELECT dbo.QUESTION.QuesID, dbo.QUESTION.QuesContent FROM dbo.QUESTION, dbo.EXAM_QUES WHERE dbo.EXAM_QUES.ExID = @examid AND QUESTION.QuesID = EXAM_QUES.QuesID
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_getRoleId]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_getRoleId](@rolename NVARCHAR(50))
AS
BEGIN
	SELECT dbo.ROLES.RoleID FROM dbo.ROLES WHERE RoleName = @rolename
END
GO
/****** Object:  StoredProcedure [dbo].[proc_getSubject]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_getSubject](@username VARCHAR(20))
AS
BEGIN
	BEGIN
		SELECT SUBJECTS.SubID, Subname  FROM dbo.TEACHER, dbo.SUBJECTS WHERE SUBJECTS.SubID = TEACHER.SubID AND Teacher = @username
	END
END
GO
/****** Object:  StoredProcedure [dbo].[proc_getUSerInfo]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_getUSerInfo] @username VARCHAR(20) AS
BEGIN
	SELECT Fullname, Gender, Birthday, Avatar, RoleName FROM dbo.USERS, dbo.ROLES WHERE ROLES.RoleID = USERS.RoleID AND Username = @username
END
GO
/****** Object:  StoredProcedure [dbo].[proc_getUserName]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_getUserName] (@username VARCHAR(20), @fullname NVARCHAR(50) OUTPUT)
AS
BEGIN
	SELECT @fullname = Fullname FROM dbo.USERS WHERE Username = @username
END
GO
/****** Object:  StoredProcedure [dbo].[proc_insertAnswer]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_insertAnswer] @anscontent NVARCHAR(max), @quesid VARCHAR(20), @iscorrect bit
AS
BEGIN
	DECLARE @ansid VARCHAR(20) 
	SELECT @ansid = dbo.autoCreateID('AN')
	INSERT INTO dbo.ANSWER
	        ( AnsID ,
	          AnsContent ,
	          QuesID ,
	          IsCorrect
	        )
	VALUES  ( @ansid , -- AnsID - varchar(20)
	          @anscontent , -- AnsContent - nvarchar(max)
	          @quesid , -- QuesID - varchar(20)
	          @iscorrect  -- IsCorrect - bit
	        )
END
GO
/****** Object:  StoredProcedure [dbo].[proc_insertClass]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_insertClass] (@classname NVARCHAR(50), @maxMember int)
AS
BEGIN

	DECLARE @classid VARCHAR(20)

	SELECT @classid = dbo.autoCreateID('CL')

	INSERT INTO dbo.CLASS
	        ( ClassID, Classname, MaxMember )
	VALUES  ( @classid, -- ClassID - varchar(20)
	          @classname, -- Classname - nvarchar(50)
	          @maxMember  -- MaxMember - int
	          )
END
GO
/****** Object:  StoredProcedure [dbo].[proc_insertExam]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_insertExam] @exname NVARCHAR(50), @timetest int, @datetest DATETIME, @username VARCHAR(20)
AS
BEGIN
	DECLARE @exid VARCHAR(20)
	SELECT @exid = dbo.autoCreateID('EX')
	DECLARE @subid VARCHAR(20)
	SELECT @subid = dbo.TEACHER.SubID FROM dbo.TEACHER WHERE Teacher = @username
	INSERT INTO dbo.EXAM
	        ( ExID ,
	          Exname ,
	          TimeTest ,
	          Creator ,
	          DateCreate ,
	          DateTest ,
	          SubjectID
	        )
	VALUES  ( @exid , -- ExID - varchar(20)
	          @exname , -- Exname - nvarchar(50)
	          @timetest , -- TimeTest - int
	          @username , -- Creator - varchar(20)
	          GETDATE() , -- DateCreate - datetime
	          @datetest , -- DateTest - datetime
	          @subid  -- SubjectID - varchar(20)
	        )
END
GO
/****** Object:  StoredProcedure [dbo].[proc_insertExamClass]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[proc_insertExamClass] @examid VARCHAR(20), @classid VARCHAR(20) AS
BEGIN
INSERT INTO dbo.CLASS_EXAM 
        ( ClassID, ExID )
VALUES  ( @classid, -- ClassID - varchar(20)
          @examid  -- ExID - varchar(20)
          )
END
GO
/****** Object:  StoredProcedure [dbo].[proc_insertExamQues]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_insertExamQues] @examid VARCHAR(20), @questionid VARCHAR(20)
AS
BEGIN
	INSERT INTO dbo.EXAM_QUES
	        ( ExID, QuesID )
	VALUES  ( @examid, -- ExID - varchar(20)
	          @questionid  -- QuesID - varchar(20)
	          )
END
GO
/****** Object:  StoredProcedure [dbo].[proc_insertListClass]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_insertListClass] (@username VARCHAR(20), @classname NVARCHAR(50))
AS
BEGIN
	DECLARE @classid VARCHAR(20)
	SELECT @classid = dbo.CLASS.ClassID FROM dbo.CLASS WHERE Classname = @classname
	IF @classid IS NOT NULL
	BEGIN
		INSERT INTO dbo.LISTCLASS
	        ( Student, ClassID )
	VALUES  ( @username, -- Student - varchar(20)
	          @classid  -- ClassID - varchar(20)
	          )
	END
END
GO
/****** Object:  StoredProcedure [dbo].[proc_insertQuestion]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_insertQuestion] @quescontent NVARCHAR(max), @typeid VARCHAR(20)
AS
BEGIN
	DECLARE @quesid VARCHAR(20) 
	SELECT @quesid = dbo.autoCreateID('QU')
	INSERT INTO dbo.QUESTION
	        ( QuesID, QuesContent, TypeID )
	VALUES  ( @quesid, -- QuesID - varchar(20)
	          @quescontent, -- QuesContent - nvarchar(max)
	          @typeid  -- TypeID - varchar(20)
	          )
END
GO
/****** Object:  StoredProcedure [dbo].[proc_insertTeacher]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_insertTeacher] @subid VARCHAR(20), @username VARCHAR(20) AS
BEGIN
	INSERT INTO dbo.TEACHER 
	        ( Teacher, SubID )
	VALUES  ( @username, -- Teacher - varchar(20)
	          @subid  -- SubID - varchar(20)
	          )
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ListAdmin]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_ListAdmin] @pageIndex INT = 1,@pageSize INT = 20,@RecordNo INT OUTPUT AS
BEGIN
SET NOCOUNT ON
	SELECT ROW_NUMBER() OVER (ORDER BY dbo.view_ListUser.Status DESC) AS RowNo, *
	INTO #tblTemp FROM dbo.view_ListUser WHERE Rolename =N'admin'
	SELECT @RecordNo = COUNT(*) FROM #tblTemp
	SELECT * FROM #tblTemp WHERE RowNo BETWEEN (@pageIndex - 1)*@pageSize +1 AND (@pageIndex - 1)* @pageSize + @pageSize
	DROP TABLE #tblTemp
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ListClass]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_ListClass] AS
BEGIN
	SELECT * FROM dbo.CLASS
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ListClassExam]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_ListClassExam] @examid VARCHAR(20)
AS
BEGIN
	SELECT dbo.CLASS_EXAM.ClassID, dbo.CLASS.Classname, (SELECT COUNT(dbo.LISTCLASS.Student) FROM dbo.LISTCLASS WHERE ClassID = dbo.CLASS_EXAM.ClassID) AS TotalStudent
	FROM dbo.CLASS, dbo.CLASS_EXAM WHERE dbo.CLASS_EXAM.ExID = @examid AND 
	dbo.CLASS_EXAM.ClassID = dbo.CLASS.ClassID
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ListClassNotExistInExam]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[proc_ListClassNotExistInExam] @examid VARCHAR(20) AS
BEGIN
--lấy thông tin và sĩ số của lớp không nằm trong kỳ thi có mã là @examid
	SELECT DISTINCT dbo.CLASS.ClassID, dbo.CLASS.Classname, (SELECT COUNT(dbo.LISTCLASS.Student) FROM dbo.LISTCLASS WHERE ClassID = dbo.CLASS.ClassID) AS TotalStudent
	FROM dbo.CLASS WHERE CLASS.ClassID NOT IN (SELECT ClassID FROM dbo.CLASS_EXAM WHERE ExID = @examid)
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ListExam]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_ListExam] @pageIndex INT = 1,@pageSize INT = 20,@RecordNo INT OUTPUT, @username VARCHAR(20) AS
BEGIN
SET NOCOUNT ON
	SELECT ROW_NUMBER() OVER (ORDER BY dbo.EXAM.DateCreate DESC) AS RowNo, ExID,Exname,TimeTest,DateCreate,DateTest
	INTO #tblTemp FROM dbo.EXAM WHERE Creator = @username
	SELECT @RecordNo = COUNT(*) FROM #tblTemp
	SELECT * FROM #tblTemp WHERE RowNo BETWEEN (@pageIndex - 1)*@pageSize +1 AND (@pageIndex - 1)* @pageSize + @pageSize
	DROP TABLE #tblTemp
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ListQuestion]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_ListQuestion] @pageIndex INT = 1,@pageSize INT = 20,@RecordNo INT OUTPUT, @username VARCHAR(20) AS
BEGIN
SET NOCOUNT ON
	SELECT ROW_NUMBER() OVER (ORDER BY dbo.QUESTION.TypeID DESC) AS RowNo, QuesID, QuesContent, Typename
	INTO #tblTemp FROM dbo.QUESTION, dbo.TYPEQUES WHERE QUESTION.TypeID = TYPEQUES.TypeID AND TYPEQUES.SubID IN (SELECT dbo.TEACHER.SubID FROM dbo.TEACHER WHERE Teacher = @username)
	SELECT @RecordNo = COUNT(*) FROM #tblTemp
	SELECT * FROM #tblTemp WHERE RowNo BETWEEN (@pageIndex - 1)*@pageSize +1 AND (@pageIndex - 1)* @pageSize + @pageSize
	DROP TABLE #tblTemp
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ListQuestionNotExistInExam]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_ListQuestionNotExistInExam] @examid VARCHAR(20) AS
BEGIN
 -- câu hỏi nằm trong môn học của kỳ thi và chưa có trong kỳ thi  
	SELECT DISTINCT QUESTION.QuesID, QuesContent FROM dbo.QUESTION JOIN dbo.TYPEQUES ON TYPEQUES.TypeID = QUESTION.TypeID JOIN dbo.SUBJECTS ON SUBJECTS.SubID = TYPEQUES.SubID
	WHERE
	QUESTION.QuesID NOT IN (SELECT QuesID FROM dbo.EXAM_QUES WHERE ExID = @examid)
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ListQuestionsOfExam]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_ListQuestionsOfExam] @pageIndex INT = 1,@pageSize INT = 20,@RecordNo INT OUTPUT, @examid VARCHAR(20) AS
BEGIN
SET NOCOUNT ON
	SELECT ROW_NUMBER() OVER (ORDER BY dbo.QUESTION.TypeID DESC) AS RowNo, QUESTION.QuesID, QuesContent, Typename, Subname
	INTO #tblTemp FROM dbo.QUESTION, dbo.TYPEQUES, dbo.SUBJECTS, dbo.EXAM_QUES WHERE QUESTION.TypeID = TYPEQUES.TypeID AND TYPEQUES.SubID = SUBJECTS.SubID AND dbo.EXAM_QUES.ExID = @examid AND QUESTION.QuesID = dbo.EXAM_QUES.QuesID
	SELECT @RecordNo = COUNT(*) FROM #tblTemp
	SELECT * FROM #tblTemp WHERE RowNo BETWEEN (@pageIndex - 1)*@pageSize +1 AND (@pageIndex - 1)* @pageSize + @pageSize
	DROP TABLE #tblTemp
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ListStudent]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_ListStudent] @pageIndex INT = 1,@pageSize INT = 20,@RecordNo INT OUTPUT AS
BEGIN
SET NOCOUNT ON
	SELECT ROW_NUMBER() OVER (ORDER BY dbo.view_ListUser.Status DESC) AS RowNo, *
	INTO #tblTemp FROM dbo.view_ListUser WHERE Rolename =N'student'
	SELECT @RecordNo = COUNT(*) FROM #tblTemp
	SELECT * FROM #tblTemp WHERE RowNo BETWEEN (@pageIndex - 1)*@pageSize +1 AND (@pageIndex - 1)* @pageSize + @pageSize
	DROP TABLE #tblTemp
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ListSubject]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_ListSubject] AS
BEGIN
	SELECT * FROM dbo.SUBJECTS
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ListTeacher]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_ListTeacher] @pageIndex INT = 1,@pageSize INT = 20,@RecordNo INT OUTPUT AS
BEGIN
SET NOCOUNT ON
	SELECT ROW_NUMBER() OVER (ORDER BY dbo.view_ListUser.Status DESC) AS RowNo, *
	INTO #tblTemp FROM dbo.view_ListUser WHERE Rolename =N'teacher'
	SELECT @RecordNo = COUNT(*) FROM #tblTemp
	SELECT * FROM #tblTemp WHERE RowNo BETWEEN (@pageIndex - 1)*@pageSize +1 AND (@pageIndex - 1)* @pageSize + @pageSize
	DROP TABLE #tblTemp
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ListUser]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_ListUser] @pageIndex INT = 1,@pageSize INT = 20,@RecordNo INT OUTPUT AS
BEGIN
SET NOCOUNT ON
	SELECT ROW_NUMBER() OVER (ORDER BY dbo.view_ListUser.Status DESC) AS RowNo, *
	INTO #tblTemp FROM dbo.view_ListUser
	SELECT @RecordNo = COUNT(*) FROM #tblTemp
	SELECT * FROM #tblTemp WHERE RowNo BETWEEN (@pageIndex - 1)*@pageSize +1 AND (@pageIndex - 1)* @pageSize + @pageSize
	DROP TABLE #tblTemp
END
GO
/****** Object:  StoredProcedure [dbo].[proc_LoginState]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_LoginState] 
(@user VARCHAR(20), @pwd VARCHAR(50), @rolename NVARCHAR(50))
AS
BEGIN
	BEGIN TRAN T
	DECLARE @status bit
	SELECT @status = Status FROM dbo.view_UserInfoLogin WHERE Username = @user AND Password = @pwd AND Rolename = @rolename
	IF @status IS NULL
	BEGIN
		ROLLBACK TRAN T
	END
	ELSE IF @status = 1
	BEGIN
	ROLLBACK TRAN T
	END
	ELSE
	BEGIN
	UPDATE dbo.USERS SET Status = 1 WHERE Username = @user
	END
	COMMIT TRAN T
END
GO
/****** Object:  StoredProcedure [dbo].[proc_StudentViewExam]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_StudentViewExam] (@username VARCHAR(20))
AS
BEGIN
	SELECT view_StudentExam.Classname,ExName,TimeTest,DateTest,Subname,exID,dbo.getExamState(exID) AS exState, dbo.getDateDiff(DateTest) AS SecondTime FROM view_StudentExam 
	  INNER JOIN dbo.CLASS
	 ON view_StudentExam.Classname = dbo.CLASS.Classname
	  INNER JOIN dbo.LISTCLASS ON dbo.CLASS.ClassID = dbo.LISTCLASS.ClassID AND dbo.LISTCLASS.Student = @username
	  WHERE ExID NOT IN (SELECT ExID FROM dbo.RESULT WHERE ExID = ExID AND Student = @username)
	  ORDER BY DateTest
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_submitExam]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_submitExam](@examid NVARCHAR(20),@username NVARCHAR(20),@mark DECIMAL(4,2),@TimeComplete NVARCHAR(50))
AS
BEGIN
	INSERT INTO dbo.RESULT 
	        ( Student, ExID, Mark, TimeComplete )
	VALUES  ( @username, -- Student - varchar(20)
	          @examid, -- ExID - varchar(20)
	          @mark,  -- Mark - decimal
			  @TimeComplete
	          )
END

GO
/****** Object:  StoredProcedure [dbo].[proc_updateAnswer]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_updateAnswer](@ansid VARCHAR(20),@quesid VARCHAR(20), @anscontent NVARCHAR(max), @iscorrect BIT) AS
BEGIN
	UPDATE dbo.ANSWER SET AnsContent = @anscontent, QuesID = @quesid, IsCorrect = @iscorrect WHERE AnsID = @ansid
END
GO
/****** Object:  StoredProcedure [dbo].[proc_updateAvatar]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_updateAvatar] @username varchar(20), @avatar nvarchar(max)
AS BEGIN
   	UPDATE dbo.USERS SET Avatar = @avatar WHERE Username = @username
   END
GO
/****** Object:  StoredProcedure [dbo].[proc_updateExam]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_updateExam] @examid VARCHAR(20), @examname NVARCHAR(50), @timetest INT, @datetest DATETIME, @username VARCHAR(20) 
AS
BEGIN
	UPDATE dbo.EXAM SET Exname = @examname, TimeTest = @timetest, DateTest = @datetest, DateCreate = GETDATE(), Creator =@username  WHERE ExID = @examid
END
GO
/****** Object:  StoredProcedure [dbo].[proc_updateListClass]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_updateListClass] @classid VARCHAR(20), @username VARCHAR(20) AS
BEGIN
	UPDATE dbo.LISTCLASS SET ClassID = @classid WHERE Student = @username
END
GO
/****** Object:  StoredProcedure [dbo].[proc_updateQues]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_updateQues](@quesid VARCHAR(20), @quescontent NVARCHAR(max), @typeid VARCHAR(20)) AS
BEGIN
	UPDATE dbo.QUESTION SET QuesContent = @quescontent, TypeID = @typeid WHERE QuesID = @quesid
END
GO
/****** Object:  StoredProcedure [dbo].[proc_updateTeacher]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_updateTeacher] @subid VARCHAR(20), @username VARCHAR(20) AS
BEGIN
IF EXISTS (SELECT * FROM dbo.TEACHER WHERE SubID = @subid AND Teacher = @username)
BEGIN
		UPDATE dbo.TEACHER SET SubID = @subid WHERE Teacher = @username
END
ELSE 
BEGIN
	INSERT INTO dbo.TEACHER 
	        ( Teacher, SubID )
	VALUES  ( @username, -- Teacher - varchar(20)
	          @subid  -- SubID - varchar(20)
	          )
END

END
GO
/****** Object:  StoredProcedure [dbo].[proc_updateUserStatus]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_updateUserStatus] @username VARCHAR(20) AS
BEGIN
	DECLARE @status BIT 
	SELECT @status = dbo.USERS.Status FROM dbo.USERS WHERE Username = @username
	IF @status = 0
	SET @status = 1;
	ELSE SET @status = 0
	UPDATE dbo.USERS SET Status = @status WHERE Username = @username
END
GO
/****** Object:  UserDefinedFunction [dbo].[autoCreateID]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[autoCreateID](@lable VARCHAR(2))
RETURNS VARCHAR(20)
AS
BEGIN

	DECLARE @id VARCHAR(20) -- Mã ID
	DECLARE @idNumber INT -- Số mã
	DECLARE @table TABLE(ID VARCHAR(20)) -- bảng cần sinh mã

	IF @lable = 'CL'
	BEGIN
		INSERT INTO @table(ID) SELECT dbo.CLASS.ClassID AS ID FROM dbo.CLASS
	END
	ELSE IF @lable = 'EX'
    BEGIN
    	INSERT INTO @table(ID) SELECT dbo.EXAM.ExID AS ID FROM dbo.EXAM
    END
	ELSE IF @lable = 'QU'
	BEGIN
		INSERT INTO @table(ID) SELECT dbo.QUESTION.QuesID AS ID FROM dbo.QUESTION
	END
	ELSE IF @lable = 'AN'
	BEGIN
		INSERT INTO @table(ID) SELECT dbo.ANSWER.AnsID AS ID FROM dbo.ANSWER
	END
	-- Lấy số mã bằng tổng số dòng trong bảng cộng 1
	SELECT @idNumber = COUNT(T.ID) + 1 FROM @table AS T
	IF @idNumber = 0 -- nếu số mã bằng 0 thì đặt lại thành 1
	SET @idNumber = 1
	-- định dạng mã
	IF @idNumber < 10
	SET @id = @lable + '00'+CONVERT(VARCHAR(10),@idNumber)
	ELSE IF @idNumber <100
	SET @id = @lable + '0'+CONVERT(VARCHAR(10),@idNumber)
	ELSE
	SET @id = @lable+CONVERT(VARCHAR(10),@idNumber)
	-- nếu mã đã tồn tại thì tăng số mã lên 1, lặp lại đến khi không còn trùng nữa
	WHILE EXISTS(SELECT ID FROM @table WHERE ID = @id)
	BEGIN
		SET @idNumber = @idNumber + 1
			IF @idNumber < 10
	SET @id = @lable + '00'+CONVERT(VARCHAR(10),@idNumber)
	ELSE IF @idNumber <100
	SET @id = @lable + '0'+CONVERT(VARCHAR(10),@idNumber)
	ELSE
	SET @id = @lable+CONVERT(VARCHAR(10),@idNumber)
	END

	RETURN @id
END

GO
/****** Object:  UserDefinedFunction [dbo].[getAvgMark]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[getAvgMark](@username VARCHAR(20))
RETURNS DECIMAL(4,2)
AS
BEGIN
	DECLARE @avgmark DECIMAL(4,2)
	SELECT @avgmark = AVG(Mark) FROM dbo.RESULT WHERE Student = @username
	RETURN @avgmark
END
GO
/****** Object:  UserDefinedFunction [dbo].[getClassName]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[getClassName] (@username VARCHAR(20)) RETURNS NVARCHAR(50) AS
BEGIN
DECLARE @classname NVARCHAR(50)
	SELECT @classname = Classname FROM dbo.LISTCLASS , dbo.CLASS WHERE CLASS.ClassID = LISTCLASS.ClassID AND Student = @username 
	RETURN @classname
END
GO
/****** Object:  UserDefinedFunction [dbo].[getDateDiff]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[getDateDiff](@datetime DATETIME) 
RETURNS INT
AS
BEGIN
	RETURN DATEDIFF(SECOND,GETDATE(),@datetime)
END
GO
/****** Object:  UserDefinedFunction [dbo].[getExamState]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[getExamState](@examid VARCHAR(20)) 
RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @state NVARCHAR(50)
	DECLARE @datestart DATETIME
	DECLARE @timetest INT
	DECLARE @TotalDateTime DATETIME

	SELECT @datestart = dbo.EXAM.DateTest,@timetest = dbo.EXAM.TimeTest FROM dbo.EXAM WHERE ExID = @examid;
		SET @TotalDateTime = DATEADD(MINUTE,@timetest,@datestart)
	IF @datestart IS NULL OR @timetest IS NULL
	RETURN N'không xác định'
	IF DATEDIFF(SECOND,@TotalDateTime,GETDATE()) > 0
	BEGIN
		RETURN N'đã thi'
	END
		if DATEDIFF(SECOND,@datestart,GETDATE()) < 0 
		BEGIN
			return N'chưa thi';
		END
	RETURN N'đang thi'
END
GO
/****** Object:  UserDefinedFunction [dbo].[isFullMember]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[isFullMember](@ClassID VARCHAR(20))
RETURNS BIT
AS
BEGIN
	DECLARE @totalMember INT
    DECLARE @maxMember INT 
	SELECT @totalMember = COUNT(dbo.LISTCLASS.Student) FROM dbo.LISTCLASS WHERE ClassID = @ClassID
	SELECT @maxMember = MaxMember FROM dbo.CLASS WHERE ClassID = @ClassID
	IF @totalMember > @maxMember
		RETURN 1
	RETURN 0
END
GO
/****** Object:  Table [dbo].[ANSWER]    Script Date: 11/15/2017 6:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ANSWER](
	[AnsID] [varchar](20) NOT NULL,
	[AnsContent] [nvarchar](max) NULL,
	[QuesID] [varchar](20) NOT NULL,
	[IsCorrect] [bit] NULL CONSTRAINT [default_iscorrect]  DEFAULT ((0)),
 CONSTRAINT [pk_answer] PRIMARY KEY CLUSTERED 
(
	[AnsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CLASS]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLASS](
	[ClassID] [varchar](20) NOT NULL,
	[Classname] [nvarchar](50) NOT NULL,
	[MaxMember] [int] NULL,
 CONSTRAINT [pk_class] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unique_classname] UNIQUE NONCLUSTERED 
(
	[Classname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CLASS_EXAM]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLASS_EXAM](
	[ClassID] [varchar](20) NOT NULL,
	[ExID] [varchar](20) NOT NULL,
 CONSTRAINT [pk_classexam] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC,
	[ExID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EXAM]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EXAM](
	[ExID] [varchar](20) NOT NULL,
	[Exname] [nvarchar](50) NOT NULL,
	[TimeTest] [int] NULL,
	[Creator] [varchar](20) NULL,
	[DateCreate] [datetime] NULL,
	[DateTest] [datetime] NULL,
	[SubjectID] [varchar](20) NULL,
 CONSTRAINT [pk_exam] PRIMARY KEY CLUSTERED 
(
	[ExID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EXAM_QUES]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EXAM_QUES](
	[ExID] [varchar](20) NOT NULL,
	[QuesID] [varchar](20) NOT NULL,
 CONSTRAINT [pk_examques] PRIMARY KEY CLUSTERED 
(
	[ExID] ASC,
	[QuesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LISTCLASS]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LISTCLASS](
	[Student] [varchar](20) NOT NULL,
	[ClassID] [varchar](20) NOT NULL,
 CONSTRAINT [PK_LISTCLASS_1] PRIMARY KEY CLUSTERED 
(
	[Student] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QUESTION]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QUESTION](
	[QuesID] [varchar](20) NOT NULL,
	[QuesContent] [nvarchar](max) NOT NULL,
	[TypeID] [varchar](20) NULL,
 CONSTRAINT [pk_question] PRIMARY KEY CLUSTERED 
(
	[QuesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RESULT]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RESULT](
	[Student] [varchar](20) NOT NULL,
	[ExID] [varchar](20) NOT NULL,
	[Mark] [decimal](4, 2) NULL,
	[TimeComplete] [nvarchar](50) NULL,
 CONSTRAINT [pk_result] PRIMARY KEY CLUSTERED 
(
	[Student] ASC,
	[ExID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ROLES]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ROLES](
	[RoleID] [varchar](20) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [pk_roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SUBJECTS]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SUBJECTS](
	[SubID] [varchar](20) NOT NULL,
	[Subname] [nvarchar](50) NOT NULL,
 CONSTRAINT [pk_subjects] PRIMARY KEY CLUSTERED 
(
	[SubID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unique_subname] UNIQUE NONCLUSTERED 
(
	[Subname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TEACHER]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TEACHER](
	[Teacher] [varchar](20) NOT NULL,
	[SubID] [varchar](20) NOT NULL,
 CONSTRAINT [pk_teacher] PRIMARY KEY CLUSTERED 
(
	[Teacher] ASC,
	[SubID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TYPEQUES]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TYPEQUES](
	[TypeID] [varchar](20) NOT NULL,
	[Typename] [nvarchar](50) NOT NULL,
	[SubID] [varchar](20) NOT NULL,
 CONSTRAINT [pk_contentgroup] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USERS](
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](50) NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Gender] [bit] NULL CONSTRAINT [default_gender]  DEFAULT ((0)),
	[Birthday] [date] NULL,
	[Avatar] [nvarchar](max) NULL CONSTRAINT [default_avatar]  DEFAULT ('avt.jpg'),
	[RoleID] [varchar](20) NULL,
	[Status] [bit] NOT NULL CONSTRAINT [default_status]  DEFAULT ((0)),
 CONSTRAINT [pk_users] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[view_ListUser]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_ListUser] AS
SELECT Username,Fullname,Gender,Birthday,Avatar,Rolename,Status FROM dbo.USERS, dbo.ROLES WHERE USERS.RoleID = ROLES.RoleID

GO
/****** Object:  View [dbo].[view_StudentExam]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_StudentExam]
AS
SELECT        dbo.CLASS.Classname, dbo.EXAM.Exname, dbo.EXAM.TimeTest, dbo.EXAM.DateTest, dbo.SUBJECTS.Subname, dbo.EXAM.ExID
FROM            dbo.CLASS INNER JOIN
                         dbo.CLASS_EXAM ON dbo.CLASS.ClassID = dbo.CLASS_EXAM.ClassID INNER JOIN
                         dbo.EXAM ON dbo.CLASS_EXAM.ExID = dbo.EXAM.ExID INNER JOIN
                         dbo.SUBJECTS ON dbo.EXAM.SubjectID = dbo.SUBJECTS.SubID

GO
/****** Object:  View [dbo].[view_UserInfoLogin]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_UserInfoLogin] AS
 SELECT dbo.USERS.Username AS Username, dbo.USERS.Password AS Password, dbo.ROLES.RoleName AS Rolename, dbo.USERS.Status AS Status
 FROM dbo.USERS,dbo.ROLES WHERE dbo.USERS.RoleID = ROLES.RoleID
GO
ALTER TABLE [dbo].[ANSWER]  WITH CHECK ADD  CONSTRAINT [fk_answer_question] FOREIGN KEY([QuesID])
REFERENCES [dbo].[QUESTION] ([QuesID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ANSWER] CHECK CONSTRAINT [fk_answer_question]
GO
ALTER TABLE [dbo].[CLASS_EXAM]  WITH CHECK ADD  CONSTRAINT [fk_classexam_class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[CLASS] ([ClassID])
GO
ALTER TABLE [dbo].[CLASS_EXAM] CHECK CONSTRAINT [fk_classexam_class]
GO
ALTER TABLE [dbo].[CLASS_EXAM]  WITH CHECK ADD  CONSTRAINT [fk_classexam_exam] FOREIGN KEY([ExID])
REFERENCES [dbo].[EXAM] ([ExID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CLASS_EXAM] CHECK CONSTRAINT [fk_classexam_exam]
GO
ALTER TABLE [dbo].[EXAM_QUES]  WITH CHECK ADD  CONSTRAINT [fk_examques_exam] FOREIGN KEY([ExID])
REFERENCES [dbo].[EXAM] ([ExID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EXAM_QUES] CHECK CONSTRAINT [fk_examques_exam]
GO
ALTER TABLE [dbo].[EXAM_QUES]  WITH CHECK ADD  CONSTRAINT [fk_examques_ques] FOREIGN KEY([QuesID])
REFERENCES [dbo].[QUESTION] ([QuesID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EXAM_QUES] CHECK CONSTRAINT [fk_examques_ques]
GO
ALTER TABLE [dbo].[LISTCLASS]  WITH CHECK ADD  CONSTRAINT [fk_listclass_class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[CLASS] ([ClassID])
GO
ALTER TABLE [dbo].[LISTCLASS] CHECK CONSTRAINT [fk_listclass_class]
GO
ALTER TABLE [dbo].[LISTCLASS]  WITH CHECK ADD  CONSTRAINT [fk_listclass_users] FOREIGN KEY([Student])
REFERENCES [dbo].[USERS] ([Username])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LISTCLASS] CHECK CONSTRAINT [fk_listclass_users]
GO
ALTER TABLE [dbo].[QUESTION]  WITH CHECK ADD  CONSTRAINT [fk_question_contentgroup] FOREIGN KEY([TypeID])
REFERENCES [dbo].[TYPEQUES] ([TypeID])
GO
ALTER TABLE [dbo].[QUESTION] CHECK CONSTRAINT [fk_question_contentgroup]
GO
ALTER TABLE [dbo].[RESULT]  WITH CHECK ADD  CONSTRAINT [fk_result_exam] FOREIGN KEY([ExID])
REFERENCES [dbo].[EXAM] ([ExID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RESULT] CHECK CONSTRAINT [fk_result_exam]
GO
ALTER TABLE [dbo].[RESULT]  WITH CHECK ADD  CONSTRAINT [fk_result_users] FOREIGN KEY([Student])
REFERENCES [dbo].[USERS] ([Username])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RESULT] CHECK CONSTRAINT [fk_result_users]
GO
ALTER TABLE [dbo].[TEACHER]  WITH CHECK ADD  CONSTRAINT [fk_teacher_subjects] FOREIGN KEY([SubID])
REFERENCES [dbo].[SUBJECTS] ([SubID])
GO
ALTER TABLE [dbo].[TEACHER] CHECK CONSTRAINT [fk_teacher_subjects]
GO
ALTER TABLE [dbo].[TEACHER]  WITH CHECK ADD  CONSTRAINT [fk_teacher_users] FOREIGN KEY([Teacher])
REFERENCES [dbo].[USERS] ([Username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TEACHER] CHECK CONSTRAINT [fk_teacher_users]
GO
ALTER TABLE [dbo].[TYPEQUES]  WITH CHECK ADD  CONSTRAINT [fk_contentgroup_subjects] FOREIGN KEY([SubID])
REFERENCES [dbo].[SUBJECTS] ([SubID])
GO
ALTER TABLE [dbo].[TYPEQUES] CHECK CONSTRAINT [fk_contentgroup_subjects]
GO
ALTER TABLE [dbo].[USERS]  WITH CHECK ADD  CONSTRAINT [fk_users_roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[ROLES] ([RoleID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[USERS] CHECK CONSTRAINT [fk_users_roles]
GO
ALTER TABLE [dbo].[EXAM]  WITH CHECK ADD  CONSTRAINT [c_timetest] CHECK  (([TimeTest]>=(0)))
GO
ALTER TABLE [dbo].[EXAM] CHECK CONSTRAINT [c_timetest]
GO
ALTER TABLE [dbo].[RESULT]  WITH CHECK ADD  CONSTRAINT [c_mark] CHECK  (([Mark]>=(0) AND [Mark]<=(10)))
GO
ALTER TABLE [dbo].[RESULT] CHECK CONSTRAINT [c_mark]
GO
ALTER TABLE [dbo].[USERS]  WITH CHECK ADD  CONSTRAINT [c_pass] CHECK  ((len([Password])>(5)))
GO
ALTER TABLE [dbo].[USERS] CHECK CONSTRAINT [c_pass]
GO
/****** Object:  Trigger [dbo].[tg_InsAnswer]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_InsAnswer] ON [dbo].[ANSWER] AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @CountAns INT
	-- đếm số lượng phương án cho trong câu hỏi khi thêm vào hoặc update
	SELECT @CountAns = COUNT(dbo.ANSWER.AnsID) FROM dbo.ANSWER, Inserted WHERE Inserted.QuesID = dbo.ANSWER.QuesID
	IF @CountAns > 4
	BEGIN
		ROLLBACK TRAN
		RAISERROR('Tối đa 4 phương án cho một câu hỏi!',16,1)
	END
END
GO
/****** Object:  Trigger [dbo].[tg_insUpdDelAnswer]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_insUpdDelAnswer] ON [dbo].[ANSWER] FOR DELETE,INSERT,UPDATE
AS
BEGIN
	DECLARE @QuestionID VARCHAR(20)
	DECLARE @AnswerID VARCHAR(20)
	DECLARE @isCorrect BIT
	-- lấy thông tin của phương án mới
	SELECT @AnswerID = Inserted.AnsID, @QuestionID = Inserted.QuesID, @isCorrect = Inserted.IsCorrect FROM Inserted
	IF @isCorrect = 1 -- nếu thêm vào đáp án đúng, báo lỗi nếu trong ANSWER đã tồn tại đáp án đúng
	BEGIN
		IF EXISTS(SELECT dbo.ANSWER.AnsID FROM dbo.ANSWER WHERE IsCorrect = 1 AND QuesID = @QuestionID AND AnsID != @AnswerID)
			BEGIN
				RAISERROR('Mỗi câu hỏi chỉ có một đáp án đúng!',16,1)
				ROLLBACK TRAN
			END 
	END
END
GO
/****** Object:  Trigger [dbo].[tg_InsUpdDelAnswerInQuestion]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tg_InsUpdDelAnswerInQuestion] ON [dbo].[ANSWER] AFTER INSERT, DELETE, UPDATE
AS
BEGIN
	DECLARE @examid VARCHAR(20)
	--nếu mã câu hỏi của phương án có trong bảng EXAM_QUES thì lấy ra mã kỳ thi
	SELECT @examid = dbo.EXAM_QUES.ExID FROM Deleted, dbo.EXAM_QUES WHERE Deleted.QuesID = dbo.EXAM_QUES.QuesID
	IF @examid IS NOT NULL
	BEGIN
		DECLARE @datestart DATETIME
		DECLARE @timetest INT
		DECLARE @TotalDateTime DATETIME
		--lấy thời gian thi
		SELECT @datestart = DateTest,@timetest = TimeTest FROM dbo.EXAM WHERE ExID = @examid; 
		-- thời gian kết thúc = thời gian thi + thời gian làm bài
		SET @TotalDateTime = DATEADD(MINUTE,@timetest,@datestart) 
		--nếu thời gian hiện tại nằm giữa thời gian thi và thời gian kết thúc
		IF DATEDIFF(SECOND,@datestart,GETDATE()) > 0 AND DATEDIFF(SECOND,@TotalDateTime,GETDATE()) < 0
			BEGIN
				ROLLBACK TRAN
				RAISERROR('Câu hỏi của phương án này nằm trong đề thi đang được thi, không thể thêm, xóa hoặc sửa!',16,1)
			END
	END
END
GO
/****** Object:  Trigger [dbo].[tg_updClass]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_updClass] ON [dbo].[CLASS] FOR UPDATE
AS
BEGIN
	BEGIN TRAN
	DECLARE @maxMemberAfter INT 
	DECLARE @maxMemberBefore INT
	DECLARE @ClassID VARCHAR(20) 
	SELECT @maxMemberAfter = Inserted.MaxMember, @ClassID = Inserted.ClassID FROM Inserted
	SELECT @maxMemberBefore = Deleted.MaxMember FROM Deleted
	IF @maxMemberAfter != @maxMemberBefore -- nếu thuộc tính maxMember bị sửa
	BEGIN
		IF dbo.isFullMember(@ClassID) = 1 -- sĩ số hiện tại lớn hơn sĩ số tối đa
		BEGIN
			ROLLBACK TRAN
			DECLARE @currentMemberNumber INT
			SELECT @currentMemberNumber = COUNT(Student) FROM dbo.LISTCLASS WHERE ClassID = @ClassID --lấy sĩ số hiện tại
			DECLARE @message NVARCHAR(100) = N'Sĩ số tối đa phải lớn hơn sĩ số hiện tại ( ' + CONVERT(NVARCHAR(10),@currentMemberNumber) + N' học sinh).'
			RAISERROR(@message,16,1)
		END
	END
	COMMIT TRAN
END
GO
/****** Object:  Trigger [dbo].[tg_InsUpdDelClassExam]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_InsUpdDelClassExam] ON [dbo].[CLASS_EXAM] AFTER DELETE, UPDATE
AS
BEGIN
BEGIN TRAN
	DECLARE @examid VARCHAR(20)
	SELECT @examid = Deleted.ExID FROM Deleted
	DECLARE @datestart DATETIME
	DECLARE @timetest INT
	DECLARE @TotalDateTime DATETIME
	SELECT @datestart = DateTest,@timetest = TimeTest FROM dbo.EXAM WHERE ExID = @examid;
	SET @TotalDateTime = DATEADD(MINUTE,@timetest,@datestart)
			-- nếu thởi gian hiện tại lớn hơn thời gian bắt đầu thi và nhỏ hơn thời gian bắt đầu thi cộng thời gian thi
	IF DATEDIFF(SECOND,@datestart,GETDATE()) > 0 AND DATEDIFF(SECOND,@TotalDateTime,GETDATE()) < 0
		BEGIN
			ROLLBACK TRAN
			RAISERROR('Kỳ thi này đang trong thời gian thi, không thể sửa hoặc xóa!',16,1)
		END
	COMMIT TRAN
END
GO
/****** Object:  Trigger [dbo].[tg_InsUpdExam]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_InsUpdExam] ON [dbo].[EXAM] FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @datetest DATETIME
	SELECT @datetest = Inserted.DateTest FROM Inserted
	DECLARE @datetestBefore DATETIME
	SET @datetestBefore = DATEADD(MINUTE,10,@datetest) -- cho datetestBefore khác với datetest
	IF EXISTS(SELECT * FROM Deleted) -- nếu là sửa
	BEGIN
		SELECT @datetestBefore = Deleted.DateTest FROM Deleted
	END
	IF @datetest != @datetestBefore -- nếu thêm hoặc sửa datetest
	BEGIN
		IF DATEDIFF(SECOND,@datetest,GETDATE()) > 0
		BEGIN
		ROLLBACK TRAN
		RAISERROR('Ngày thi phải lớn hơn ngày hiện tại!',16,1)
		END
	END
END
GO
/****** Object:  Trigger [dbo].[tg_UpdDelExam]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_UpdDelExam] ON [dbo].[EXAM]
AFTER DELETE, UPDATE
AS
BEGIN
	DECLARE @examid VARCHAR(20)
	SELECT @examid = Deleted.ExID FROM Deleted

	DECLARE @datestart DATETIME
	DECLARE @timetest INT
	DECLARE @TotalDateTime DATETIME
	SELECT @datestart = Deleted.DateTest,@timetest = Deleted.TimeTest FROM Deleted WHERE ExID = @examid;
	SET @TotalDateTime = DATEADD(MINUTE,@timetest,@datestart)
			-- nếu thởi gian hiện tại lớn hơn thời gian bắt đầu thi và nhỏ hơn thời gian bắt đầu thi cộng thời gian thi
	IF DATEDIFF(SECOND,@datestart,GETDATE()) > 0 AND DATEDIFF(SECOND,@TotalDateTime,GETDATE()) < 0
		BEGIN
			ROLLBACK TRAN
			RAISERROR('Kỳ thi này đang trong thời gian thi, không thể sửa hoặc xóa!',16,1)
		END
END
GO
/****** Object:  Trigger [dbo].[tg_InsUpdDelExamQuestion]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_InsUpdDelExamQuestion] ON [dbo].[EXAM_QUES] AFTER DELETE, INSERT, UPDATE
AS
BEGIN
	DECLARE @examid VARCHAR(20)
	SELECT @examid = Inserted.ExID FROM Inserted
	DECLARE @datestart DATETIME
	DECLARE @timetest INT
	DECLARE @TotalDateTime DATETIME
	SELECT @datestart = DateTest,@timetest = TimeTest FROM dbo.EXAM WHERE ExID = @examid;
	SET @TotalDateTime = DATEADD(MINUTE,@timetest,@datestart)
			-- nếu thởi gian hiện tại lớn hơn thời gian bắt đầu thi và nhỏ hơn thời gian bắt đầu thi cộng thời gian thi
	IF DATEDIFF(SECOND,@datestart,GETDATE()) > 0 AND DATEDIFF(SECOND,@TotalDateTime,GETDATE()) < 0
		BEGIN
			ROLLBACK TRAN
			RAISERROR('Kỳ thi này đang trong thời gian thi, không thể thêm, sửa hoặc xóa thông tin!',16,1)
		END
END
GO
/****** Object:  Trigger [dbo].[tg_insUpdListClass]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_insUpdListClass] ON [dbo].[LISTCLASS] FOR INSERT,UPDATE
AS
BEGIN
	BEGIN TRAN
	DECLARE @ClassID VARCHAR(20)
	SELECT @ClassID = Inserted.ClassID FROM Inserted
	-- sử dụng hàm kiểm tra sĩ số hiện tại có lớn hơn sĩ số tối đa hay không (nếu có trả về giá trị 1)
	IF dbo.isFullMember(@ClassID) = 1
		BEGIN
			ROLLBACK TRAN
			RAISERROR('Lớp đã đủ số lượng học sinh!',16,1)
		END
	COMMIT
END
GO
/****** Object:  Trigger [dbo].[tg_UpdDelQuestion]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_UpdDelQuestion] ON [dbo].[QUESTION] AFTER DELETE, UPDATE
AS
BEGIN
BEGIN TRAN
	DECLARE @examid VARCHAR(20)
	--nếu câu hỏi có trong bảng EXAM_QUES thì lấy ra mã kỳ thi
	SELECT @examid = dbo.EXAM_QUES.ExID FROM Deleted, dbo.EXAM_QUES WHERE Deleted.QuesID = dbo.EXAM_QUES.QuesID
	IF @examid IS NOT NULL
	BEGIN
		DECLARE @datestart DATETIME
		DECLARE @timetest INT
		DECLARE @TotalDateTime DATETIME
		--lấy thời gian thi
		SELECT @datestart = DateTest,@timetest = TimeTest FROM dbo.EXAM WHERE ExID = @examid; 
		-- thời gian kết thúc = thời gian thi + thời gian làm bài
		SET @TotalDateTime = DATEADD(MINUTE,@timetest,@datestart) 
		--nếu thời gian hiện tại nằm giữa thời gian thi và thời gian kết thúc
		IF DATEDIFF(SECOND,@datestart,GETDATE()) > 0 AND DATEDIFF(SECOND,@TotalDateTime,GETDATE()) < 0
			BEGIN
				ROLLBACK TRAN
				RAISERROR('Câu hỏi này nằm trong đề thi đang được thi, không thể xóa hoặc sửa!',16,1)
			END
	END
	COMMIT TRAN
END
GO
/****** Object:  Trigger [dbo].[tg_delUpdUser]    Script Date: 11/15/2017 6:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_delUpdUser]
ON [dbo].[USERS]
FOR DELETE
AS
BEGIN
	BEGIN TRAN 
	DECLARE @username VARCHAR(20)
	SELECT @username = username FROM Deleted WHERE Deleted.RoleID = '3' --role of user is admin
	IF @username IS NOT NULL -- nếu thao tác trên user có role admin
		BEGIN
			BEGIN
				RAISERROR('Không thể xóa Admin',16,1)
				ROLLBACK TRAN
			END
		END
	ELSE
	COMMIT TRAN
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CLASS"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CLASS_EXAM"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EXAM"
            Begin Extent = 
               Top = 102
               Left = 38
               Bottom = 232
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SUBJECTS"
            Begin Extent = 
               Top = 102
               Left = 246
               Bottom = 198
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_StudentExam'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_StudentExam'
GO
USE [master]
GO
ALTER DATABASE [QuanLyThiTracNghiemOnline] SET  READ_WRITE 
GO

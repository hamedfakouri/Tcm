﻿USE TCMBeta
GO

/****** Object:  UserDefinedFunction [dbo].[StringFarsi]    Script Date: 01/29/2019 22:13:01 ******/

CREATE FUNCTION [dbo].[StringFarsi]
    (
      @InputString AS NVARCHAR(MAX)
    )
RETURNS NVARCHAR(MAX)
AS 
    BEGIN
		RETURN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
			@InputString, NCHAR(1609), NCHAR(1740)), 
						  NCHAR(1610), NCHAR(1740)), 
						  NCHAR(64508), NCHAR(1740)), 
						  NCHAR(64509), NCHAR(1740)), 
						  NCHAR(64510), NCHAR(1740)), 
						  NCHAR(64511), NCHAR(1740)), 
						  NCHAR(65263), NCHAR(1740)), 
						  NCHAR(65264), NCHAR(1740)), 
						  NCHAR(65265), NCHAR(1740)), 
						  NCHAR(65266), NCHAR(1740)), 
						  NCHAR(65267), NCHAR(1740)), 
						  NCHAR(65268), NCHAR(1740)), 
						  NCHAR(64399), NCHAR(1705)), 
						  NCHAR(64400), NCHAR(1705)), 
						  NCHAR(64401), NCHAR(1705)), 
						  NCHAR(64398), NCHAR(1705)), 
						  NCHAR(65241), NCHAR(1705)), 
						  NCHAR(65242), NCHAR(1705)), 
						  NCHAR(65243), NCHAR(1705)), 
						  NCHAR(65244), NCHAR(1705)), 
						  NCHAR(1603), NCHAR(1705)),
						  CHAR(237), NCHAR(1740))
    END

GO


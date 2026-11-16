-- Run once against the CarDealer database before deploying password hashing.
-- Existing plaintext passwords are upgraded to PBKDF2 hashes at each user's next successful login.
ALTER TABLE [dbo].[Customer] ALTER COLUMN [password] NVARCHAR(200) NOT NULL;
ALTER TABLE [dbo].[Staff] ALTER COLUMN [password] NVARCHAR(200) NOT NULL;

# SmartVault

SmartVault will create a SQLite database and fill it with 10 users who have thousands of documents saved into the database.

## SmartVault.CodeGeneration

This project generates code that is used in the SmartVault.Program library.

## SmartVault.DataGeneration

This project generates a SQLite database with users, accounts, and documents. Previously it was taking several minutes to run, so the process has been optimized in several ways:

1. Document inserts are batched instead of being run sequentially.
2. The user and account queries are executed in an earlier, non-nested loop.
3. Loop-unrolling has been applied to the nested for loop that creates documents for insertion. It now takes about 6500 ms to run on a 2020 MacBook Pro with 8 GB of memory.

SQL statements have been broken off into private methods to follow the DRY principle. They have been updated to include values for the DateCreated field.

## SmartVault.Program

This project contains the business logic information for SmartVault. The Account, Document, and User business objects have been updated to include a DateCreated field.

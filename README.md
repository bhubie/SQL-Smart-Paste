# SQL-Smart-Paste

SQL Server Management Studio extention for pasting copied items as properly formatted ready to use SQL expressions. 

# Installing

1. Download the latest [release](https://github.com/bhubie/SQL-Smart-Paste/releases).
2. Find the Extenstion folder of your SSMS Version and unzip the folder into it.

   **SSMS 18 Default install location:**
   
   `C:\Program Files (x86)\Microsoft SQL Server Management Studio 18\Common7\IDE\Extensions`
  
   **SSMS 17 Default install location:**
   
   `C:\Program Files (x86)\Microsoft SQL Server\140\Tools\Binn\ManagementStudio\Extensions`
  
3. The first time you launch SSMS, it may show a warning message saying something is wrong with the extension and that it did not load correctly. Click No, and restart SSMS.  The extension should now work correctly.

# Usage

1. Copy Text
2. in the SSMS text editor, right-click and select either Paste as CSV or Paste as Varchar CSV. 

   Paste as CSV will paste the copied text into the editor as a comma separated list, preserving the data type.
   
   Paste as Varchar CSV will paste the copied text into the editor as a VarChar comma separated list no matter the data type.

![alt text](https://github.com/bhubie/SQL-Smart-Paste/blob/master/DemoImages/SQLSmartPasteExample.gif)

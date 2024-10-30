# VCF Name Fix

This was written because of me having an issue with the way my contacts were showing up as "Last Name First Name" instead of "First Name Last Name" in Messages. At some point in ~July 2024 this started occuring:

https://www.reddit.com/r/GooglePixel/comments/1eks9ax/contacts_in_text_messages_showing_last_name/

Special thanks to abmuemzl who got me pointed in the right direction to resolve

Google Contacts supporting help: https://support.google.com/contacts/answer/7199294?hl=en&co=GENIE.Platform%3DDesktop

**This assumes your contacts are generic first name last name, the code *should* handle special prefixes and suffixes but I didn't test and I don't have contacts saved that way**

## Steps to fix

1. Go to your Google Contacts page - https://contacts.google.com/u/0/
2. Select all (select one and then you can click drop down to select all)
   
   ![image](https://github.com/user-attachments/assets/9f6d629d-1725-497d-9626-549befa17515)
3. Afterwards click the ... and export as VCF
   
   ![image](https://github.com/user-attachments/assets/cb91c93d-973f-403f-9eaa-a6e0033ba3da)
   ![image](https://github.com/user-attachments/assets/8f974761-e57e-4740-b8a7-1434f704e492)
4. Be sure to **BACKUP THIS FILE SOMEWHERE**!!! In case things go wrong this file will have everything as it currently stands
5. Download this VCF Name Fix program and run it
   - Get the program zip here - https://github.com/dragpent/VCF-Name-Fix/releases/download/v1.0.0/VCF.Name.Fix.zip
   - Unzip the file
   - Run VCF Name Fix.exe
   - Microsoft Defender won't like this but you can click More info, and Run anyway (if anyone knows a better way to release let me know, new to releasing specifically)

![image](https://github.com/user-attachments/assets/24bc0487-4e2e-4571-9078-3ee79aaa377f)

![image](https://github.com/user-attachments/assets/7ab7b8a4-c614-4c72-b887-722166358cbf)

![image](https://github.com/user-attachments/assets/078177d1-b8f4-478a-a2d7-adf08277c0b6)

6. Click "Open VCF File" to upload the VCF file from step 3
7. Once file is loaded "Process and Save" will be available - click this, this will update the data and save a new VCF file onto your desktop. ~Desktop\FixedVCF.vcf
   - Do a sanity check and review the data and confirm the data now looks correct (you can use notepad to open review)
8. In Google Contacts select all again (step 2) but delete contacts this time

   - Note that these deleted contacts will still be in your Trash if there is a need to restore
     
   ![image](https://github.com/user-attachments/assets/cf38f2f4-3762-461c-8544-9a7ea7389d58)
9. Import the FixedVCF.vcf file from your desktop to Google Contacts 

   ![image](https://github.com/user-attachments/assets/e614a0af-46ec-4784-a55d-5eedf673b461)

10. This import will create a label with the date, you can delete this label to keep your contacts clean after confirming all is looking correct.

   ![image](https://github.com/user-attachments/assets/8c100820-23ac-4b38-a2f2-dcb88de0b275)
   
11. Success?

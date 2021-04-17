using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    class NewTournament
    {
        /*
        When creating a new tournament, do the following:
        1. See that masterskapstips@gmail.com still works
        2. Go to BlobStorage and delete from container: Tips
        3. Log into to the database and do INSERT INTO and DELETE FROM these tables
           - TipsComments
           - TipsPathToPDFs
        4. Delete this table
           - TipsDatas
        5. Update CodeGenerator -> Program -> CreateTeamsListInAlphabeticOrder
        6. Update CodeGenerator -> Program -> CreateGamesList
        7. Run CodeGenerator
        8. Run two SQL scripts.
        9. Open .edmx and delete the TipsData entity model. SAVE! Then add TipsData again. SAVE!
        10. Copy all automated generated files with code into the correct places
        11. See that TournamentStartTime is later than right now
        12. Set BlobPassword and MailPassword in local file
        13. Run web site 
            - Leave a comment
            - Participate in tips
            - Created in TipsDatas?
            - PDF created in Blob Storage?
            - Email with PDF sent?
            - Path to PDF saved in database?
            - Download PDF and open
        14. Check CommentController
        15. Check PaymentController
        16. Check Start page and see that someone payed
        17. Check TextfileController
        18. Change TournamentStartTime in web.config
        19. Check ResultController
        20. Read all texts and see that they are correct
            - Everything on site before tournament
            - Everything on site after tournament start
            - Mail sent out


        
        Deploy to 'test'        
        101. Go to web app settings/config blade and chande keys to database and blob storage if needed.
        102. Deploy
        103. Make alla tests from above 13 - 20


        Before Real launch
        201. Set Tournament starttime to two hours before us, or one hour, due to local time and UTC.
        202. Check that it seems to work.
        203. Set the real Tournament start time
        202. Log into to the database and do DELETE FROM these tables
             - DELETE FROM Tipsdatas WHERE Id > 1
             - DELETE FROM TipsPathToPDFs
             - DELETE FROM TipsComments
        203. Go into blob storage and delete PDFs.
        204. Remote text from text files
        205. Check appsettings so that correct values are present
        
        
        Push code to Git. NOT web.config
        

         */
    }
}

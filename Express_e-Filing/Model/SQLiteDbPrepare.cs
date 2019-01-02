using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using CC;
using Express_e_Filing.Misc;
using System.Windows.Forms;

namespace Express_e_Filing.Model
{
    public class SQLiteDbPrepare/* : DbContext*/
    {
        public const string taxonomy_matching_file_name = "TAXONOMY.RDB";

        //public SQLiteDbPrepare(SccompDbf sccomp) :
        //    base(new SQLiteConnection()
        //    {
        //        ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = sccomp.GetAbsolutePath() + taxonomy_matching_file_name, ForeignKeys = true }.ConnectionString
        //    }, true)
        //{

        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    base.OnModelCreating(modelBuilder);
        //}

        //public DbSet<boj5_header> boj5_header { get; set; }
        //public DbSet<boj5_person> boj5_person { get; set; }
        //public DbSet<boj5_detail> boj5_detail { get; set; }
        //public DbSet<glacc_match> glacc_match { get; set; }

        public static void EnsureDbCreated(SccompDbf sccomp)
        {
            try
            {
                if (!Directory.Exists(sccomp.GetAbsolutePath()))
                {
                    XMessageBox.Show("ค้นหาไดเร็คทอรี่ " + sccomp.GetAbsolutePath() + " ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(sccomp.GetAbsolutePath() + SQLiteDbPrepare.taxonomy_matching_file_name))
                {
                    SQLiteConnection.CreateFile(sccomp.GetAbsolutePath() + SQLiteDbPrepare.taxonomy_matching_file_name);

                    using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + sccomp.GetAbsolutePath() + SQLiteDbPrepare.taxonomy_matching_file_name + @";Version=3;"))
                    {
                        using (SQLiteCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "CREATE TABLE IF NOT EXISTS glacc_match(id INTEGER PRIMARY KEY, accnum TEXT, depcod TEXT, taxodesc TEXT, taxodesc2 TEXT)";

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                }

                UpgradeDB(sccomp);
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
            }
        }

        public static void UpgradeDB(SccompDbf sccomp)
        {
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + sccomp.GetAbsolutePath() + SQLiteDbPrepare.taxonomy_matching_file_name + @";Version=3;"))
            {
                using (SQLiteCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "PRAGMA foreign_keys = 0;";
                    cmd.CommandText += "CREATE TABLE glacc_match_temp_table AS SELECT* FROM glacc_match;";
                    cmd.CommandText += "DROP TABLE glacc_match;";
                    cmd.CommandText += "CREATE TABLE glacc_match(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, accnum TEXT, depcod TEXT, taxodesc TEXT, taxodesc2 TEXT);";
                    cmd.CommandText += "INSERT INTO glacc_match(id, accnum, depcod, taxodesc, taxodesc2) SELECT id, accnum, depcod, taxodesc, taxodesc2 FROM glacc_match_temp_table;";
                    cmd.CommandText += "DROP TABLE glacc_match_temp_table;";
                    cmd.CommandText += "PRAGMA foreign_keys = 1;";

                    cmd.CommandText += "CREATE TABLE IF NOT EXISTS boj5_header(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, userId TEXT, accSource TEXT, meetingType TEXT, meetingNo TEXT, sourceDate DATE, totalCapital REAL, totalShare INTEGER, parValue REAL, thaiShareholder INTEGER, totalThaiShare INTEGER, foreignShareholder INTEGER, totalForeignShare INTEGER, headerStatus TEXT, yearEnd DATE);";
                    cmd.CommandText += "CREATE TABLE IF NOT EXISTS boj5_person(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, addrForeign TEXT, addrFull TEXT, addrNo TEXT, amphur TEXT, holderName TEXT, itemSeq INTEGER, moo TEXT, nationality TEXT, occupation TEXT, province TEXT, road TEXT, shId TEXT, shType TEXT, soi TEXT, surname TEXT, title TEXT, tumbol TEXT);";
                    cmd.CommandText += "CREATE TABLE IF NOT EXISTS boj5_detail(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, itemNo INTEGER, userId TEXT, shareNumber INTEGER, shareType TEXT, paidAmount REAL, asPaidAmount REAL, shareDocId TEXT, shareDocDate DATE, shareRegExist DATE, shareRegOmit DATE, boj5_person_id INTEGER NOT NULL, FOREIGN KEY(boj5_person_id) REFERENCES boj5_person(id));"; //, FOREIGN KEY(boj5_person_id) REFERENCES boj5_person(id)

                    //cmd.CommandText += "INSERT INTO boj5_header (id, userId, accSource, meetingType, meetingNo, sourceDate, totalCapital, ) VALUES ()";
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }


    

    





    

    



}

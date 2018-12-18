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
    public class SQLiteDbContext : DbContext
    {
        public const string taxonomy_matching_file_name = "TAXONOMY.RDB";

        public SQLiteDbContext(SccompDbf sccomp) :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = sccomp.GetAbsolutePath() + taxonomy_matching_file_name, ForeignKeys = true }.ConnectionString
            }, true)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<glacc_match> glacc_match { get; set; }

        public static void EnsureDbCreated(SccompDbf sccomp)
        {
            try
            {
                if (!Directory.Exists(sccomp.GetAbsolutePath()))
                {
                    XMessageBox.Show("ค้นหาไดเร็คทอรี่ " + sccomp.GetAbsolutePath() + " ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(sccomp.GetAbsolutePath() + SQLiteDbContext.taxonomy_matching_file_name))
                {
                    SQLiteConnection.CreateFile(sccomp.GetAbsolutePath() + SQLiteDbContext.taxonomy_matching_file_name);

                    using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + sccomp.GetAbsolutePath() + SQLiteDbContext.taxonomy_matching_file_name + @";Version=3;"))
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
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + sccomp.GetAbsolutePath() + SQLiteDbContext.taxonomy_matching_file_name + @";Version=3;"))
            {
                using (SQLiteCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS boj5_header(id INTEGER PRIMARY KEY, userId TEXT, accSource TEXT, meetingType TEXT, meetingNo TEXT, sourceDate TEXT, totalCapital REAL, totalShare INTEGER, parValue REAL, thaiShareholder INTEGER, totalThaiShare INTEGER, foreignShareholder INTEGER, totalForeignShare INTEGER, headerStatus TEXT, yearEnd TEXT);";
                    cmd.CommandText += "CREATE TABLE IF NOT EXISTS share_holder(id INTEGER PRIMARY KEY, addrForeign TEXT, addrFull TEXT, addrNo TEXT, amphur TEXT, asPaidAmount REAL, holderName TEXT, itemNo INTEGER, userId TEXT, itemSeq INTEGER, moo TEXT, nationality TEXT, occupation TEXT, paidAmount REAL, province TEXT, road TEXT, shId TEXT, shType TEXT, shareDocDate TEXT, shareDocId TEXT, shareNumber INTEGER, shareRegExist TEXT, shareRegOmit TEXT, shareType TEXT, soi TEXT, surname TEXT, title TEXT, tumbol TEXT);";
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }

    
}

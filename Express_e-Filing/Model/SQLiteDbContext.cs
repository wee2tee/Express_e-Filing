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

                return;

            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return;
            }
        }
    }

    
}

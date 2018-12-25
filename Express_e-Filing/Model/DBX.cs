using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Express_e_Filing.Misc;

namespace Express_e_Filing.Model
{
    public class DBX : LocalDbEntities
    {
        public static LocalDbEntities DataSet(SccompDbf sccomp)
        {
            try
            {
                //@"metadata=res://*/Model.LocalDbModel.csdl|res://*/Model.LocalDbModel.ssdl|res://*/Model.LocalDbModel.msl;provider=System.Data.SQLite.EF6;provider connection string=\"data source=D:\Express\ExpressI\87\TAXONOMY.RDB\";"

                string conn_str = "metadata=res://*/Model.LocalDbModel.csdl|res://*/Model.LocalDbModel.ssdl|res://*/Model.LocalDbModel.msl;provider=System.Data.SQLite.EF6;provider connection string=\"data source = " + sccomp.GetAbsolutePath() + "\\TAXONOMY.RDB\";";

                return new LocalDbEntities(conn_str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

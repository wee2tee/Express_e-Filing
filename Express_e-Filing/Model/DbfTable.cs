﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CC;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using Express_e_Filing.Misc;
using Express_e_Filing.Model;
using Express_e_Filing.SubForm;

namespace Express_e_Filing.Model
{
    public class DbfTable
    {
        public static string secure_path
        {
            get
            {
                return Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName) + @"\Secure\";
            }
        }

        public static OleDbConnection GetConnection(string data_path)
        {
            if (!Directory.Exists(data_path))
            {
                XMessageBox.Show("ค้นหาไดเร็คทอรี่ " + data_path + " ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return null;
            }
            else
            {
                return new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path);
            }
        }

        public static List<SccompDbf> GetSccompList()
        {
            List<SccompDbf> sccomp = new List<SccompDbf>();

            if (!Directory.Exists(DbfTable.secure_path))
            {
                XMessageBox.Show("ค้นหาไดเร็คทอรี่ Secure ไม่พบ, \n    อาจเป็นเพราะท่านติดตั้งโปรแกรม Express e-Filing ไว้ในตำแหน่งที่ไม่ถูกต้อง", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return sccomp;
            }
            else
            {
                using (OleDbConnection conn = DbfTable.GetConnection(secure_path) /*new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + secure_path)*/)
                {
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Select * From sccomp Order By compnam ASC";

                    DataTable dt = new DataTable();
                    conn.Open();
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        conn.Close();
                        foreach (DataRow row in dt.Rows)
                        {
                            sccomp.Add(new SccompDbf
                            {
                                candel = !row.IsNull("candel") ? row.Field<string>("candel").TrimEnd() : string.Empty,
                                compcod = !row.IsNull("compcod") ? row.Field<string>("compcod").TrimEnd() : string.Empty,
                                compnam = !row.IsNull("compnam") ? row.Field<string>("compnam").TrimEnd() : string.Empty,
                                gendat = !row.IsNull("gendat") ? (DateTime?)row.Field<DateTime>("gendat") : null,
                                path = !row.IsNull("path") ? row.Field<string>("path").TrimEnd() : string.Empty
                            });
                        }
                    }
                }

                return sccomp;
            }
        }

        public static IsinfoDbf GetIsinfo(SccompDbf sccomp)
        {
            if (!Directory.Exists(sccomp.GetAbsolutePath()))
            {
                XMessageBox.Show("ค้นหาไดเร็คทอรี่ " + sccomp.GetAbsolutePath() + " ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return null;
            }
            else
            {
                using (OleDbConnection conn = DbfTable.GetConnection(sccomp.GetAbsolutePath()))
                {
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Select * From isinfo";

                    DataTable dt = new DataTable();
                    conn.Open();
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        conn.Close();
                        if (dt.Rows.Count == 0)
                            return null;


                        return new IsinfoDbf
                        {
                            addr01 = !dt.Rows[0].IsNull("addr01") ? dt.Rows[0].Field<string>("addr01").TrimEnd() : string.Empty,
                            addr01eng = !dt.Rows[0].IsNull("addr01eng") ? dt.Rows[0].Field<string>("addr01eng").TrimEnd() : string.Empty,
                            addr02 = !dt.Rows[0].IsNull("addr02") ? dt.Rows[0].Field<string>("addr02").TrimEnd() : string.Empty,
                            addr02eng = !dt.Rows[0].IsNull("addr02eng") ? dt.Rows[0].Field<string>("addr02eng").TrimEnd() : string.Empty,
                            engnam = !dt.Rows[0].IsNull("engnam") ? dt.Rows[0].Field<string>("engnam").TrimEnd() : string.Empty,
                            taxid = !dt.Rows[0].IsNull("taxid") ? dt.Rows[0].Field<string>("taxid").TrimEnd() : string.Empty,
                            telnum = !dt.Rows[0].IsNull("telnum") ? dt.Rows[0].Field<string>("telnum").TrimEnd() : string.Empty,
                            thinam = !dt.Rows[0].IsNull("thinam") ? dt.Rows[0].Field<string>("thinam").TrimEnd() : string.Empty,
                            trdreg = !dt.Rows[0].IsNull("trdreg") ? dt.Rows[0].Field<string>("trdreg").TrimEnd() : string.Empty,
                        };
                    }
                }
            }
        }

        public static List<GlaccDbf> GetGlaccList(SccompDbf sccomp)
        {
            List<GlaccDbf> glacc = new List<GlaccDbf>();

            if (!Directory.Exists(sccomp.GetAbsolutePath()))
            {
                XMessageBox.Show("ค้นหาไดเร็คทอรี่ " + sccomp.GetAbsolutePath() + " ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return glacc;
            }
            else
            {
                using (OleDbConnection conn = DbfTable.GetConnection(sccomp.GetAbsolutePath()))
                {
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Select * From glacc Order By accnum ASC";

                    DataTable dt = new DataTable();
                    conn.Open();
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        conn.Close();
                        foreach (DataRow row in dt.Rows)
                        {
                            int indent_space = !row.IsNull("level") ? (Convert.ToInt32(row.Field<decimal>("level")) -1) * 4 : 0;

                            glacc.Add(new GlaccDbf
                            {
                                accnam = !row.IsNull("accnam") ? row.Field<string>("accnam").TrimEnd().AddIndent(indent_space) : string.Empty,
                                accnam2 = !row.IsNull("accnam2") ? row.Field<string>("accnam2").TrimEnd().AddIndent(indent_space) : string.Empty,
                                accnum = !row.IsNull("accnum") ? row.Field<string>("accnum").TrimEnd() : string.Empty,
                                acctyp = !row.IsNull("acctyp") ? row.Field<string>("acctyp").TrimEnd() : string.Empty,
                                group = !row.IsNull("group") ? row.Field<string>("group").TrimEnd() : string.Empty,
                                level = !row.IsNull("level") ? row.Field<decimal>("level") : -1,
                                nature = !row.IsNull("nature") ? row.Field<string>("nature").TrimEnd() : string.Empty,
                                parent = !row.IsNull("parent") ? row.Field<string>("parent").TrimEnd() : string.Empty,
                                status = !row.IsNull("status") ? row.Field<string>("status").TrimEnd() : string.Empty,
                                usedep = !row.IsNull("usedep") ? row.Field<string>("usedep").TrimEnd() : string.Empty
                            });
                        }
                    }
                }
                return glacc;
            }
        }
    }

    public class SccompDbf
    {
        public string compnam { get; set; }
        public string compcod { get; set; }
        public string path { get; set; }
        public DateTime? gendat { get; set; }
        public string candel { get; set; }

    }

    public class SccompDbfVM
    {
        public SccompDbf sccomp { get; set; }
        public string compnam { get { return this.sccomp.compnam; } }
        public string compcod { get { return this.sccomp.compcod; } }
        public string path { get { return this.sccomp.path; } }
    }

    public class IsinfoDbf
    {
        public string thinam { get; set; }
        public string addr01 { get; set; }
        public string addr02 { get; set; }
        public string telnum { get; set; }
        public string engnam { get; set; }
        public string addr01eng { get; set; }
        public string addr02eng { get; set; }
        public string trdreg { get; set; }
        public string taxid { get; set; }

    }

    public class GlaccDbf
    {
        public string accnum { get; set; }
        public string accnam { get; set; }
        public string accnam2 { get; set; }
        public decimal level { get; set; }
        public string parent { get; set; }
        public string group { get; set; }
        public string acctyp { get; set; }
        public string usedep { get; set; }
        public string nature { get; set; }
        public string status { get; set; }
    }

    public class GlaccTaxonomyVM
    {
        public GlaccDbf glacc { get; set; }
        public string accnum { get; set; }
        public string accnam { get; set; }
        public string accnam2 { get; set; }
        public string taxonomy1 { get; set; }
        public string taxonomy2 { get; set; }
    }
}

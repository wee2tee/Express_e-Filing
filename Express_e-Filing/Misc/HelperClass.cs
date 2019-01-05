using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Express_e_Filing.Model;
using Express_e_Filing.SubForm;
using CC;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace Express_e_Filing.Misc
{
    public enum FORM_MODE
    {
        READ,
        EDIT
    }

    public enum OPTIONS
    {
        EFILING_TMP_DIR
    }

    public static class HelperClass
    {
        public static options GetOptions(this OPTIONS options_key, SccompDbf selected_comp)
        {
            try
            {
                using (LocalDbEntities db = DBX.DataSet(selected_comp))
                {
                    options opt = db.options.Where(o => o.key == options_key.ToString()).FirstOrDefault();

                    if (opt != null)
                    {
                        return opt;
                    }
                    else
                    {
                        options o = new options { key = options_key.ToString() };
                        db.options.Add(o);
                        db.SaveChanges();
                        return o;
                    }
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return null;
            }
        }

        public static int SaveOptions(this options options_to_save, SccompDbf selected_comp)
        {
            try
            {
                using (LocalDbEntities db = DBX.DataSet(selected_comp))
                {
                    options option = db.options.Where(o => o.key == options_to_save.key).FirstOrDefault();
                    if(option != null) // update
                    {
                        option.value_datetime = options_to_save.value_datetime;
                        option.value_num = options_to_save.value_num;
                        option.value_str = options_to_save.value_str;

                        return db.SaveChanges();
                    }
                    else // add new
                    {
                        db.options.Add(options_to_save);
                        return db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return 0;
            }
        }

        public static string GetAbsolutePath(this SccompDbf sccomp)
        {
            
                string path_txt = string.Empty;

                string p = sccomp.path;
                if (sccomp.path.Contains("("))
                    p = sccomp.path.Substring(0, sccomp.path.IndexOf("("));

                if (p.Contains(@":\") || p.StartsWith(@"\\"))
                {
                    path_txt = p.Trim();
                }
                else
                {
                    DirectoryInfo dir_info = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                    string absolute_path = dir_info.Parent.FullName + @"\" + p.Trim();
                    path_txt = absolute_path;
                }

                return path_txt.TrimEnd('\\') + @"\";
        }

        public static SccompDbfVM ToViewModel(this SccompDbf sccomp)
        {
            if (sccomp == null)
                return null;

            SccompDbfVM s = new SccompDbfVM
            {
                sccomp = sccomp
            };

            return s;
        }

        public static List<SccompDbfVM> ToViewModel(this IEnumerable<SccompDbf> sccomp)
        {
            List<SccompDbfVM> s = new List<SccompDbfVM>();

            foreach (var item in sccomp)
            {
                s.Add(item.ToViewModel());
            }

            return s;
        }

        public static GlaccTaxonomyVM ToViewModel(this GlaccDbf glacc)
        {
            if (glacc == null)
                return null;

            GlaccTaxonomyVM g = new GlaccTaxonomyVM
            {
                glacc = glacc,
                accnam = glacc.accnam,
                accnam2 = glacc.accnam2,
                accnum = glacc.accnum,
                taxonomy1 = string.Empty,
                taxonomy2 = string.Empty
            };

            return g;
        }

        public static List<GlaccTaxonomyVM> ToViewModel(this IEnumerable<GlaccDbf> glacc)
        {
            List<GlaccTaxonomyVM> g = new List<GlaccTaxonomyVM>();

            foreach (var item in glacc)
            {
                g.Add(item.ToViewModel());
            }

            return g;
        }

        public static boj5_detail_VM ToViewModel(this boj5_detail detail)
        {
            if (detail == null)
                return null;

            boj5_detail_VM b = new boj5_detail_VM
            {
                boj5_detail = detail
            };
            return b;
        }

        public static List<boj5_detail_VM> ToViewModel(this IEnumerable<boj5_detail> details)
        {
            List<boj5_detail_VM> b = new List<boj5_detail_VM>();

            foreach (var item in details)
            {
                b.Add(item.ToViewModel());
            }
            return b;
        }

        public static boj5_person_VM ToViewModel(this boj5_person person)
        {
            if (person == null)
                return null;

            boj5_person_VM p = new boj5_person_VM
            {
                boj5_person = person
            };
            return p;
        }

        public static List<boj5_person_VM> ToViewModel(this IEnumerable<boj5_person> persons)
        {
            List<boj5_person_VM> p = new List<boj5_person_VM>();

            foreach (var item in persons)
            {
                p.Add(item.ToViewModel());
            }
            return p;
        }

        public static string AddIndent(this string str, int indent_space)
        {
            string ret_str = string.Empty;
            for (int i = 0; i < indent_space; i++)
            {
                ret_str += " ";
            }

            return ret_str += str;
        }

        public static void SetControlState(this Component comp, FORM_MODE[] form_mode_to_enable, FORM_MODE form_mode, string accessibility_by_scacclv = null)
        {
            if (form_mode_to_enable.ToList().Where(fm => fm == form_mode).Count() > 0)
            {
                if (comp is ToolStripButton)
                {
                    ((ToolStripButton)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((ToolStripButton)comp).Enabled = false;

                    return;
                }
                if (comp is ToolStripSplitButton)
                {
                    ((ToolStripSplitButton)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((ToolStripSplitButton)comp).Enabled = false;

                    return;
                }
                if (comp is ToolStripDropDownButton)
                {
                    ((ToolStripDropDownButton)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((ToolStripDropDownButton)comp).Enabled = false;

                    return;
                }
                if (comp is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((ToolStripMenuItem)comp).Enabled = false;

                    return;
                }
                if (comp is TabControl)
                {
                    ((TabControl)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((TabControl)comp).Enabled = false;

                    return;
                }
                if (comp is Button)
                {
                    ((Button)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((Button)comp).Enabled = false;

                    return;
                }
                if (comp is DataGridView)
                {
                    ((DataGridView)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((DataGridView)comp).Enabled = false;

                    return;
                }
                if (comp is XTextEdit)
                {
                    ((XTextEdit)comp)._ReadOnly = false;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((XTextEdit)comp)._ReadOnly = true;

                    return;
                }
                if (comp is XDropdownList)
                {
                    ((XDropdownList)comp)._ReadOnly = false;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((XDropdownList)comp)._ReadOnly = true;

                    return;
                }
                if (comp is XDatePicker)
                {
                    ((XDatePicker)comp)._ReadOnly = false;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((XDatePicker)comp)._ReadOnly = true;

                    return;
                }
                if (comp is XBrowseBox)
                {
                    ((XBrowseBox)comp)._ReadOnly = false;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((XBrowseBox)comp)._ReadOnly = true;

                    return;
                }
                if(comp is RadioButton)
                {
                    ((RadioButton)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((RadioButton)comp).Enabled = false;

                    return;
                }
            }
            else
            {
                if (comp is ToolStripButton)
                {
                    ((ToolStripButton)comp).Enabled = false; return;
                }
                if (comp is ToolStripSplitButton)
                {
                    ((ToolStripSplitButton)comp).Enabled = false; return;
                }
                if (comp is ToolStripDropDownButton)
                {
                    ((ToolStripDropDownButton)comp).Enabled = false; return;
                }
                if (comp is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)comp).Enabled = false; return;
                }
                if (comp is TabControl)
                {
                    ((TabControl)comp).Enabled = false; return;
                }
                if (comp is Button)
                {
                    ((Button)comp).Enabled = false; return;
                }
                if (comp is DataGridView)
                {
                    ((DataGridView)comp).Enabled = false; return;
                }
                if (comp is XTextEdit)
                {
                    ((XTextEdit)comp)._ReadOnly = true; return;
                }
                if (comp is XDropdownList)
                {
                    ((XDropdownList)comp)._ReadOnly = true; return;
                }
                if (comp is XDatePicker)
                {
                    ((XDatePicker)comp)._ReadOnly = true; return;
                }
                if (comp is XBrowseBox)
                {
                    ((XBrowseBox)comp)._ReadOnly = true; return;
                }
                if(comp is RadioButton)
                {
                    ((RadioButton)comp).Enabled = false; return;
                }
            }
        }

        public static void SetControlVisibility(this Component comp, FORM_MODE[] form_mode_to_visible, FORM_MODE form_mode)
        {
            if (form_mode_to_visible.Where(fm => fm == form_mode).Count() > 0)
            {
                if (comp is Control)
                {
                    ((Control)comp).Visible = true; return;
                }
            }
            else
            {
                if (comp is Control)
                {
                    ((Control)comp).Visible = false; return;
                }
            }
        }

        public static void SetInlineControlPosition(this Control inline_control, DataGridView dgv, int row_index, int column_index)
        {
            if (inline_control != null)
            {
                Rectangle rect = dgv.GetCellDisplayRectangle(column_index, row_index, true);
                inline_control.SetBounds(rect.X, rect.Y + 1, rect.Width - 1, rect.Height - 3);
            }
        }

        public static List<string> GetFileNameListInZip(string archiveFilenameIn)
        {
            List<string> file_name = new List<string>();

            using (var fs = new FileStream(archiveFilenameIn, FileMode.Open, FileAccess.Read))
            {
                using (var zf = new ZipFile(fs))
                {
                    foreach (ZipEntry ze in zf)
                    {
                        if (ze.IsDirectory)
                            continue;

                        Console.Out.WriteLine(ze.Name);
                        file_name.Add(ze.Name);

                        //using (Stream s = zf.GetInputStream(ze))
                        //{
                        //    byte[] buf = new byte[4096];
                        //    // Analyze file in memory using MemoryStream.
                        //    using (MemoryStream ms = new MemoryStream())
                        //    {
                        //        StreamUtils.Copy(s, ms, buf);
                        //    }
                        //    // Uncomment the following lines to store the file
                        //    // on disk.
                        //    /*using (FileStream fs = File.Create(@"c:\temp\uncompress_" + ze.Name))
                        //    {
                        //      StreamUtils.Copy(s, fs, buf);
                        //    }*/
                        //}
                    }
                }
            }

            return file_name;
        }

        public static void ExtractZipFile(string archiveFilenameIn, string password, string outFolder)
        {
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = new ZipFile(fs);
                if (!String.IsNullOrEmpty(password))
                {
                    zf.Password = password;     // AES encrypted entries are handled automatically
                }
                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue;           // Ignore directories
                    }
                    String entryFileName = zipEntry.Name;
                    // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    byte[] buffer = new byte[4096];     // 4K is optimum
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    // Manipulate the output filename here as desired.
                    String fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }
            }
            catch(Exception ex)
            {
                XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources
                }
            }
        }

        public static void CreateZipFile(string outPathname, string password, string folderName)
        {

            FileStream fsOut = File.Create(outPathname);
            ZipOutputStream zipStream = new ZipOutputStream(fsOut);

            zipStream.SetLevel(3); //0-9, 9 being the highest level of compression

            zipStream.Password = password;  // optional. Null is the same as not setting. Required if using AES.

            // This setting will strip the leading part of the folder path in the entries, to
            // make the entries relative to the starting folder.
            // To include the full path for each entry up to the drive root, assign folderOffset = 0.
            int folderOffset = folderName.Length + (folderName.EndsWith("\\") ? 0 : 1);

            CompressFolder(folderName, zipStream, folderOffset);

            zipStream.IsStreamOwner = true; // Makes the Close also Close the underlying stream
            zipStream.Close();
        }

        // Recurses down the folder structure
        //
        private static void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
        {

            string[] files = Directory.GetFiles(path);

            foreach (string filename in files)
            {

                FileInfo fi = new FileInfo(filename);

                string entryName = filename.Substring(folderOffset); // Makes the name in zip based on the folder
                entryName = ZipEntry.CleanName(entryName); // Removes drive from name and fixes slash direction
                ZipEntry newEntry = new ZipEntry(entryName);
                newEntry.DateTime = fi.LastWriteTime; // Note the zip format stores 2 second granularity

                // Specifying the AESKeySize triggers AES encryption. Allowable values are 0 (off), 128 or 256.
                // A password on the ZipOutputStream is required if using AES.
                //   newEntry.AESKeySize = 256;

                // To permit the zip to be unpacked by built-in extractor in WinXP and Server2003, WinZip 8, Java, and other older code,
                // you need to do one of the following: Specify UseZip64.Off, or set the Size.
                // If the file may be bigger than 4GB, or you do not need WinXP built-in compatibility, you do not need either,
                // but the zip will be in Zip64 format which not all utilities can understand.
                //   zipStream.UseZip64 = UseZip64.Off;
                newEntry.Size = fi.Length;

                zipStream.PutNextEntry(newEntry);

                // Zip the file in buffered chunks
                // the "using" will close the stream even if an exception occurs
                byte[] buffer = new byte[4096];
                using (FileStream streamReader = File.OpenRead(filename))
                {
                    StreamUtils.Copy(streamReader, zipStream, buffer);
                }
                zipStream.CloseEntry();
            }
            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                CompressFolder(folder, zipStream, folderOffset);
            }
        }
    }
}

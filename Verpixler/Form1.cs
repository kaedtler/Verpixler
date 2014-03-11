using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Verpixler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte version = Convert.ToByte(comboBox1.SelectedItem.ToString());

            switch (version)
            {
                case 1:
                    {
                        OpenFileDialog open = new OpenFileDialog();
                        open.Multiselect = false;
                        if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(open.FileName))
                        {
                            FileInfo file = new FileInfo(open.FileName);

                            if (file.Length < int.MaxValue - 9)
                            {
                                byte[] size = BitConverter.GetBytes(file.Length);

                                int width = (int)Math.Ceiling(Math.Sqrt(Math.Ceiling(((double)file.Length + 9d) / 3)));
                                Bitmap bmp = new Bitmap(width, width);

                                int counter = 0;

                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(version, size[0], size[1])); counter++;
                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(size[2], size[3], size[4])); counter++;
                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(size[5], size[6], size[7])); counter++;

                                byte? r = null, g = null, b = null;

                                using (FileStream stream = file.OpenRead())
                                    for (int byt = stream.ReadByte(); byt >= 0; byt = stream.ReadByte())
                                    {
                                        if (r == null)
                                            r = (byte)byt;
                                        else if (g == null)
                                            g = (byte)byt;
                                        else if (b == null)
                                        {
                                            b = (byte)byt;
                                            bmp.SetPixel(counter % width, counter / width, Color.FromArgb((byte)r, (byte)g, (byte)b));
                                            r = g = b = null;
                                            counter++;
                                        }
                                    }

                                if (r != null)
                                {
                                    bmp.SetPixel(counter % width, counter / width, Color.FromArgb((byte)r, g == null ? 0 : (byte)g, b == null ? 0 : (byte)b));
                                }

                                SaveFileDialog save = new SaveFileDialog();
                                save.Filter = "*.png|*.png";
                                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    bmp.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png);
                                    MessageBox.Show("Verpixeln erfolgreich beendet!");
                                }
                            }
                            else
                                MessageBox.Show("Datei ist zu groß!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    break;
                case 2:
                    {
                        OpenFileDialog open = new OpenFileDialog();
                        open.Multiselect = false;
                        if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(open.FileName))
                        {
                            FileInfo file = new FileInfo(open.FileName);

                            if (file.Length < int.MaxValue - 9)
                            {
                                byte[] size = BitConverter.GetBytes(file.Length);

                                int width = (int)Math.Ceiling(Math.Sqrt(Math.Ceiling(((double)file.Length + 9d))));
                                Bitmap bmp = new Bitmap(width, width);

                                int counter = 0;

                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(version, version, version)); counter++;
                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(size[0], size[0], size[0])); counter++;
                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(size[1], size[1], size[1])); counter++;
                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(size[2], size[2], size[2])); counter++;
                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(size[3], size[3], size[3])); counter++;
                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(size[4], size[4], size[4])); counter++;
                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(size[5], size[5], size[5])); counter++;
                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(size[6], size[6], size[6])); counter++;
                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(size[7], size[7], size[7])); counter++;

                                using (FileStream stream = file.OpenRead())
                                    for (int byt = stream.ReadByte(); byt >= 0; byt = stream.ReadByte())
                                    {
                                        bmp.SetPixel(counter % width, counter / width, Color.FromArgb((byte)byt, (byte)byt, (byte)byt));
                                        counter++;
                                    }

                                SaveFileDialog save = new SaveFileDialog();
                                save.Filter = "*.png|*.png";
                                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    bmp.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png);
                                    MessageBox.Show("Verpixeln erfolgreich beendet!");
                                }
                            }
                            else
                                MessageBox.Show("Datei ist zu groß!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    break;
                case 3:
                    {
                        OpenFileDialog open = new OpenFileDialog();
                        open.Multiselect = false;
                        if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(open.FileName))
                        {
                            FileInfo file = new FileInfo(open.FileName);

                            if (file.Length < int.MaxValue - 9)
                            {
                                byte[] size = BitConverter.GetBytes(file.Length);

                                int width = (int)Math.Ceiling(Math.Sqrt(Math.Ceiling(((double)file.Length + 9d) / 4)));
                                Bitmap bmp = new Bitmap(width, width);

                                int counter = 0;

                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(version, size[0], size[1], size[2])); counter++;
                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(size[3], size[4], size[5], size[6])); counter++;
                                bmp.SetPixel(counter % width, counter / width, Color.FromArgb(size[7], 0, 0, 0)); counter++;

                                byte? a = null, r = null, g = null, b = null;

                                using (FileStream stream = file.OpenRead())
                                    for (int byt = stream.ReadByte(); byt >= 0; byt = stream.ReadByte())
                                    {
                                        if (a == null)
                                            a = (byte)byt;
                                        else if (r == null)
                                            r = (byte)byt;
                                        else if (g == null)
                                            g = (byte)byt;
                                        else if (b == null)
                                        {
                                            b = (byte)byt;
                                            bmp.SetPixel(counter % width, counter / width, Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b));
                                            a = r = g = b = null;
                                            counter++;
                                        }
                                    }

                                if (a != null)
                                {
                                    bmp.SetPixel(counter % width, counter / width, Color.FromArgb((byte)a, r == null ? 0 : (byte)r, g == null ? 0 : (byte)g, b == null ? 0 : (byte)b));
                                }

                                SaveFileDialog save = new SaveFileDialog();
                                save.Filter = "*.png|*.png";
                                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    bmp.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png);
                                    MessageBox.Show("Verpixeln erfolgreich beendet!");
                                }
                            }
                            else
                                MessageBox.Show("Datei ist zu groß!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "*.png|*.png";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(open.FileName))
            {
                Bitmap bmp = (Bitmap)Bitmap.FromFile(open.FileName);
                if (bmp != null)
                {
                    byte version = bmp.GetPixel(0, 0).R;
                    switch (version)
                    {
                        case 1:
                            {
                                int counter = 0;
                                long size = 0;
                                int width = bmp.Width;
                                if (bmp.Width * bmp.Height >= 4 && bmp.Width == bmp.Height)
                                {
                                    byte[] sizeArray = new byte[8];
                                    sizeArray[0] = bmp.GetPixel(counter % width, counter / width).G;
                                    sizeArray[1] = bmp.GetPixel(counter % width, counter / width).B;
                                    counter++;
                                    sizeArray[2] = bmp.GetPixel(counter % width, counter / width).R;
                                    sizeArray[3] = bmp.GetPixel(counter % width, counter / width).G;
                                    sizeArray[4] = bmp.GetPixel(counter % width, counter / width).B;
                                    counter++;
                                    sizeArray[5] = bmp.GetPixel(counter % width, counter / width).R;
                                    sizeArray[6] = bmp.GetPixel(counter % width, counter / width).G;
                                    sizeArray[7] = bmp.GetPixel(counter % width, counter / width).B;
                                    counter++;
                                    size = BitConverter.ToInt64(sizeArray, 0);
                                    if (bmp.Width * bmp.Height * 3 - 9 < size)
                                        size = bmp.Width * bmp.Height * 3 - 9;
                                    SaveFileDialog save = new SaveFileDialog();
                                    save.OverwritePrompt = true;
                                    if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        FileStream stream = new FileStream(save.FileName, FileMode.Create);
                                        for (; size > 0; counter++)
                                        {
                                            Color c = bmp.GetPixel(counter % width, counter / width);
                                            stream.WriteByte(c.R);
                                            size--;
                                            if (size > 0)
                                            {
                                                stream.WriteByte(c.G);
                                                size--;
                                            }
                                            if (size > 0)
                                            {
                                                stream.WriteByte(c.B);
                                                size--;
                                            }
                                        }
                                        stream.Flush();
                                        stream.Close();
                                        MessageBox.Show("Entpixeln erfolgreich beendet!");
                                    }
                                }
                                else
                                    MessageBox.Show("Bild ist Fehlerhaft!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        default:
                            MessageBox.Show("Format wird nicht unterstützt!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                    }
                }
                else
                    MessageBox.Show("Datei ist kein Bild!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

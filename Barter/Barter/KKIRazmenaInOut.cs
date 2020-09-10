using Domen;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Barter
{
    public class KKIRazmenaInOut
    {
        public event Action FrmClose;
        public BindingList<RazmenaRobe> data = new BindingList<RazmenaRobe>();
        public BindingList<RazmenaRobe> trazenaRoba = new BindingList<RazmenaRobe>();
        public BindingList<RazmenaRobe> prihvacenaRazmena = new BindingList<RazmenaRobe>();
        public BindingList<RazmenaRobe> odbijenaRazmena = new BindingList<RazmenaRobe>();
        public BindingList<RazmenaRobe> zavrsenaRazmena = new BindingList<RazmenaRobe>();
        public BindingList<RazmenaRobe> arhiviranaRazmena = new BindingList<RazmenaRobe>();

        // end
        internal void SrediFormu(string title, DataGridView dgvRazmena, Label lblTitle, TabControl tabControlRazmena)
        {
            try
            {
                // Razmena in - end
                if (title == "RAZMENA IN")
                {
                    data = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiListuRazmeneRobe(Sesija.Instance.Korisnik, "KorisnikUlozeneRobe ="));

                    // novo
                    trazenaRoba = new BindingList<RazmenaRobe>(data.Where(k => k.PotvrdaRazmene == null && k.ZavrsenaRazmena == null && k.ArhiviranaRazmena == null).ToList());
                    prihvacenaRazmena = new BindingList<RazmenaRobe>(data.Where(k => k.PotvrdaRazmene == true && k.ZavrsenaRazmena == null && k.ArhiviranaRazmena == null).ToList());
                    odbijenaRazmena = new BindingList<RazmenaRobe>(data.Where(k => k.PotvrdaRazmene == false && k.ZavrsenaRazmena == null && k.ArhiviranaRazmena == null).ToList());
                    //zavrsena roba
                    zavrsenaRazmena = new BindingList<RazmenaRobe>(data.Where(k => k.ZavrsenaRazmena == true).ToList());
                    //arhivirana roba
                    arhiviranaRazmena = new BindingList<RazmenaRobe>(data.Where(k => k.ArhiviranaRazmena == true).ToList());

                    // sredjivanje dgvTrazenaRoba
                    ((DataGridView)tabControlRazmena.TabPages["tabPage1"].Controls["dgvRazmenaTrazeneRobe"]).Columns[6].Visible = false;
                    ((DataGridView)tabControlRazmena.TabPages["tabPage1"].Controls["dgvRazmenaTrazeneRobe"]).Columns[7].Visible = false;
                    ((DataGridView)tabControlRazmena.TabPages["tabPage1"].Controls["dgvRazmenaTrazeneRobe"]).DataSource = trazenaRoba;

                    // sredjivanje dgvPrihvacenaRazmene

                    ((DataGridView)tabControlRazmena.TabPages["tabPage2"].Controls["dgvPrihvacenaRazmena"]).DataSource = prihvacenaRazmena;
                    ((DataGridView)tabControlRazmena.TabPages["tabPage2"].Controls["dgvPrihvacenaRazmena"]).DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;

                    // sredjivanje dgvOdbijeneRazmene
                    ((DataGridView)tabControlRazmena.TabPages["tabPage3"].Controls["dgvOdbijenaRazmena"]).DataSource = odbijenaRazmena;
                    ((DataGridView)tabControlRazmena.TabPages["tabPage3"].Controls["dgvOdbijenaRazmena"]).DefaultCellStyle.BackColor = System.Drawing.Color.Red;

                    // sredjivanje dgvZavrsenaRazmena
                    ((DataGridView)tabControlRazmena.TabPages["tabPage4"].Controls["dgvZavrsenaRazmena"]).DataSource = zavrsenaRazmena;
                    ((DataGridView)tabControlRazmena.TabPages["tabPage4"].Controls["dgvZavrsenaRazmena"]).DefaultCellStyle.BackColor = System.Drawing.Color.DarkGreen;

                    // sredjivanje dgvArhiviranaRazmena
                    ((DataGridView)tabControlRazmena.TabPages["tabPage5"].Controls["dgvArhiviranaRazmena"]).DataSource = arhiviranaRazmena;
                    ((DataGridView)tabControlRazmena.TabPages["tabPage5"].Controls["dgvArhiviranaRazmena"]).DefaultCellStyle.BackColor = System.Drawing.Color.Gray;

                    // stari dgv
                    dgvRazmena.DataSource = data;
                    dgvRazmena.Columns[6].Visible = false;
                    dgvRazmena.Columns[7].Visible = false;
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (data[i].PotvrdaRazmene == true) dgvRazmena.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Green;
                        if (data[i].PotvrdaRazmene == false) dgvRazmena.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;

                        foreach (var roba in data[i].UlozenaRoba)
                        {
                            ((DataGridViewTextBoxCell)dgvRazmena.Rows[i].Cells["UlozenaRoba"]).Value += roba.NazivRobe + " " + roba.KolicinaRobe + ",\n";
                        }
                    }
                }

                // Razmena Out - end
                if (title == "RAZMENA OUT")
                {
                    lblTitle.Text = title;
                    data = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiListuRazmeneRobe(Sesija.Instance.Korisnik, "KorisnikTrazeneRobe ="));
                    dgvRazmena.DataSource = data;

                    for (int i = 0; i < data.Count; i++)
                    {
                        if (data[i].PotvrdaRazmene == true) dgvRazmena.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Green;
                        if (data[i].PotvrdaRazmene == false) dgvRazmena.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        foreach (var roba in data[i].UlozenaRoba)
                        {
                            ((DataGridViewTextBoxCell)dgvRazmena.Rows[i].Cells["UlozenaRoba"]).Value += roba.NazivRobe + " " + roba.KolicinaRobe + "g,\n";
                        }
                    }
                }
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
        }

        //
        internal void OnClick(object sender, DataGridViewCellEventArgs e, DataGridView dgvRazmena)
        {
            if(sender is DataGridView)
            {
                DataGridView dgv = (DataGridView)sender;

                // trazena roba


                // prihvacena razmena
                if(dgv.Name == "dgvPrihvacenaRazmena")
                {
                    if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        try
                        {
                            // zavrsi razmenu
                            if (e.ColumnIndex == 6)
                            {
                                if (MessageBox.Show("Da li zelite da zavrsite razmenu?", "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    // message box da li ste sigurni da hocete da zavrsite razmenu?
                                    prihvacenaRazmena[e.RowIndex].PotvrdaRazmene = false;
                                    prihvacenaRazmena[e.RowIndex].ZavrsenaRazmena = true;
                                    if (Komunikacija.Instance.PotvrdaRazmeneRobe(prihvacenaRazmena[e.RowIndex], true))
                                    {
                                        zavrsenaRazmena.Add(prihvacenaRazmena[e.RowIndex]);
                                        prihvacenaRazmena.Remove(prihvacenaRazmena[e.RowIndex]);
                                        MessageBox.Show($"Uspesno zavrsena razmena!");
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Neuspena zavrsena razmena!");
                                    }
                                }
                            }
                            // ponistiti razmenu
                            if (e.ColumnIndex == 7)
                            {
                                if (MessageBox.Show("Da li zelite da ponistite razmenu?", "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    prihvacenaRazmena[e.RowIndex].PotvrdaRazmene = false;
                                    if (Komunikacija.Instance.PonistiRazmenuRobe(prihvacenaRazmena[e.RowIndex]))
                                    {
                                        odbijenaRazmena.Add(prihvacenaRazmena[e.RowIndex]);
                                        prihvacenaRazmena.Remove(prihvacenaRazmena[e.RowIndex]);
                                        MessageBox.Show($"Uspesno ponistena razmena!");
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Neuspesno ponistena razmena!");
                                    }
                                }
                            }
                            // pdf jedne razmene
                            if (e.ColumnIndex == 8)
                            {
                                MessageBox.Show($"PDF jedne razmene!");
                            }
                        }
                        catch (ExceptionServer es)
                        {
                            FrmClose();
                            throw new ExceptionServer(es.Message);
                        }
                    }
                }

                // odbijena razmena


                // zavrsena razmena


            }

            //var senderGrid = (DataGridView)sender;

            //if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
            //{
            //    try
            //    {
            //        if (e.ColumnIndex == 7) dgvRazmena.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Green;
            //        if (e.ColumnIndex == 8) dgvRazmena.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
            //    }
            //    catch (ExceptionServer es)
            //    {
            //        FrmClose();
            //        throw new ExceptionServer(es.Message);
            //    }
            //}

            //if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            //{
            //    try
            //    {
            //        // potvrda razmene
            //        if(e.ColumnIndex == 6)
            //        {
            //            data[e.RowIndex].PotvrdaRazmene = true;
            //            if (Komunikacija.Instance.PotvrdaRazmeneRobe(data[e.RowIndex], true))
            //            {
            //                MessageBox.Show($"Uspesna potvrda razmene!");
            //                senderGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Green;
            //            }
            //            else
            //            {
            //                MessageBox.Show($"Neuspena potvrda razmene!");
            //            } 
            //        }
            //        // ponistiti razmenu
            //        if(e.ColumnIndex == 7)
            //        {
            //            data[e.RowIndex].PotvrdaRazmene = false;
            //            if (Komunikacija.Instance.PonistiRazmenuRobe(data[e.RowIndex]))
            //            {
            //                MessageBox.Show($"Uspesno ponistena razmena!");
            //                senderGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
            //            }
            //            else
            //            {
            //                MessageBox.Show($"Neuspesno ponistena razmena!");
            //            }
            //        }
            //        // brisanje razmene 
            //        if (e.ColumnIndex == 8)
            //        {
            //            if (Komunikacija.Instance.ObrisiRazmenuRobe(data[e.RowIndex]))
            //            {
            //                MessageBox.Show($"Uspesno izbrisana razmena!");
            //                data.Remove(data[e.RowIndex]);
            //            }
            //            else
            //            {
            //                MessageBox.Show($"Neuspeno izbrisana razmena!");
            //            }
            //        }
            //        // prf jedne razmene
            //        if (e.ColumnIndex == 9)
            //        {

            //        }
            //    }
            //    catch (ExceptionServer es)
            //    {
            //        FrmClose();
            //        throw new ExceptionServer(es.Message);
            //    }
            //}

        }

        // export to pdf
        internal void exportGridToPdf(DataGridView dgvRazmena, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            //
            PdfPTable pdfTable = new PdfPTable(dgvRazmena.Columns.Count - 4); 
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            Font text = new Font(bf, 10, Font.NORMAL);
            //Add header
            foreach(DataGridViewColumn column in dgvRazmena.Columns)
            {
                if (column.Index > 5) break;
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }
            //Add datarow
            foreach(DataGridViewRow row in dgvRazmena.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 5) break;
                    if(cell.Value is DateTime)
                    {
                        pdfTable.AddCell(new Phrase(((DateTime)cell.Value).ToString("dd/MM/yyyy"), text));
                        continue;
                    }
                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = filename;
            saveFileDialog.DefaultExt = ".pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4_LANDSCAPE);
                    Font font = FontFactory.GetFont(Font.FontFamily.TIMES_ROMAN.ToString(), 15, BaseColor.BLACK);
                    Font fontTitle = FontFactory.GetFont(Font.FontFamily.TIMES_ROMAN.ToString(), 20, Font.BOLD, BaseColor.BLACK);

                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    System.Drawing.Image image1 = System.Drawing.Image.FromFile("C://Users/Nemanja/Desktop/NRCompar.png");
                    Image iTextImage1 = Image.GetInstance(image1, System.Drawing.Imaging.ImageFormat.Png);
                    iTextImage1.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(iTextImage1);

                    Paragraph parag1 = new Paragraph("Celokupni izveštaj razmene", fontTitle);
                    parag1.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(parag1);
                    pdfDoc.Add(new Paragraph(" "));

                    Paragraph parag2 = new Paragraph("Korisnik: " + Sesija.Instance.Korisnik.ImeKorisnika + " " + Sesija.Instance.Korisnik.PrezimeKorisnika, font);
                    parag2.Alignment = Element.ALIGN_LEFT;
                    pdfDoc.Add(parag2);

                    Paragraph parag3 = new Paragraph("Datum izvestaja: " + DateTime.Now.ToString("dd/MM/yyyy"), font);
                    parag3.Alignment = Element.ALIGN_LEFT;
                    pdfDoc.Add(parag3);

                    pdfDoc.Add(new Paragraph(" "));

                    pdfDoc.AddAuthor(Sesija.Instance.Korisnik.ImeKorisnika + " " + Sesija.Instance.Korisnik.PrezimeKorisnika);

                    pdfDoc.Add(pdfTable);

                    pdfDoc.Close();
                    stream.Close();
                }
            }

        }

        // end
        internal void PretragaRobe(string text, DataGridView dgvRazmena, string title)
        {
            try
            {
                // Razmena in - end
                if (title == "RAZMENA IN")
                {
                    dgvRazmena.DataSource = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiPretraguRazmeneRobe(Sesija.Instance.Korisnik, $"KorisnikUlozeneRobe = {text}"));
                }

                // Razmena Out - end
                if (title == "RAZMENA OUT")
                {
                    dgvRazmena.DataSource = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiPretraguRazmeneRobe(Sesija.Instance.Korisnik, $"KorisnikTrazeneRobe = {text}"));
                }
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
        }
    }
}

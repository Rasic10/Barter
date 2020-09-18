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

        internal void SrediFormu(string title, Label lblTitle, Label lblOpisForme, TabControl tabControlRazmena)
        {
            try
            {
                // Razmena in - end
                if (title == "RAZMENA IN")
                {
                    data = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiListuRazmeneRobe(Sesija.Instance.Korisnik, "KorisnikUlozeneRobe ="));

                    // sredjivanje dataGridView-a
                    ((DataGridView)tabControlRazmena.TabPages["tabPage1"].Controls["dgvRazmenaTrazeneRobe"]).Columns[6].Visible = false;
                    ((DataGridView)tabControlRazmena.TabPages["tabPage1"].Controls["dgvRazmenaTrazeneRobe"]).Columns[7].Visible = false;

                    poveziSvakiDataGridView(data, tabControlRazmena);
                }

                // Razmena Out - end
                if (title == "RAZMENA OUT")
                {
                    lblTitle.Text = title;
                    lblOpisForme.Text = "Razmena OUT - prikaz razmena koje neko od Vas potražuje.";
                    data = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiListuRazmeneRobe(Sesija.Instance.Korisnik, "KorisnikTrazeneRobe ="));

                    // sredjivanje dataGridView-a
                    ((DataGridView)tabControlRazmena.TabPages["tabPage2"].Controls["dgvPrihvacenaRazmena"]).Columns[6].Visible = false;
                    ((DataGridView)tabControlRazmena.TabPages["tabPage2"].Controls["dgvPrihvacenaRazmena"]).Columns[7].Visible = false;
                    ((DataGridView)tabControlRazmena.TabPages["tabPage3"].Controls["dgvOdbijenaRazmena"]).Columns[6].Visible = false;
                    ((DataGridView)tabControlRazmena.TabPages["tabPage4"].Controls["dgvZavrsenaRazmena"]).Columns[6].Visible = false;

                    poveziSvakiDataGridView(data, tabControlRazmena);
                }
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
        }

        private void poveziSvakiDataGridView(BindingList<RazmenaRobe> data, TabControl tabControlRazmena)
        {
            trazenaRoba = new BindingList<RazmenaRobe>(data.Where(k => k.PotvrdaRazmene == null && k.ZavrsenaRazmena == null && k.ArhiviranaRazmena == null).ToList());
            prihvacenaRazmena = new BindingList<RazmenaRobe>(data.Where(k => k.PotvrdaRazmene == true && k.ZavrsenaRazmena == null && k.ArhiviranaRazmena == null).ToList());
            odbijenaRazmena = new BindingList<RazmenaRobe>(data.Where(k => k.PotvrdaRazmene == false && k.ZavrsenaRazmena == null && k.ArhiviranaRazmena == null).ToList());
            zavrsenaRazmena = new BindingList<RazmenaRobe>(data.Where(k => k.ZavrsenaRazmena == true).ToList());
            arhiviranaRazmena = new BindingList<RazmenaRobe>(data.Where(k => k.ArhiviranaRazmena == true).ToList());

            // sredjivanje dgvTrazenaRoba
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
        }

        internal void OnClick(object sender, DataGridViewCellEventArgs e, DataGridView dgvRazmena)
        {
            if(sender is DataGridView)
            {
                DataGridView dgv = (DataGridView)sender;

                // trazena roba
                if (dgv.Name == "dgvRazmenaTrazeneRobe")
                {
                    if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        try
                        {
                            // potvrdi razmenu
                            if (e.ColumnIndex == 6)
                            {
                                if (MessageBox.Show("Da li želite da potvrdite razmenu?", "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    trazenaRoba[e.RowIndex].PotvrdaRazmene = true;
                                    if (Komunikacija.Instance.PotvrdaRazmeneRobe(trazenaRoba[e.RowIndex], true))
                                    {
                                        prihvacenaRazmena.Add(trazenaRoba[e.RowIndex]);
                                        trazenaRoba.Remove(trazenaRoba[e.RowIndex]);
                                        MessageBox.Show($"Uspešno potvrđena razmena!");
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Neuspešno potvrđena razmena!");
                                    }
                                }
                            }
                            // ponistiti razmenu
                            if (e.ColumnIndex == 7)
                            {
                                if (MessageBox.Show("Da li želite da odbijete razmenu?", "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    trazenaRoba[e.RowIndex].PotvrdaRazmene = false;
                                    if (Komunikacija.Instance.PonistiRazmenuRobe(trazenaRoba[e.RowIndex]))
                                    {
                                        odbijenaRazmena.Add(trazenaRoba[e.RowIndex]);
                                        trazenaRoba.Remove(trazenaRoba[e.RowIndex]);
                                        MessageBox.Show($"Uspešno odbijena razmena!");
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Neuspešno odbijena razmena!");
                                    }
                                }
                            }
                            // pdf jedne razmene
                            if (e.ColumnIndex == 8)
                            {
                                exportRowToPdf(trazenaRoba[e.RowIndex], "Izveštaj");
                                MessageBox.Show($"Uspešno sačuvan PDF!");
                            }
                        }
                        catch (ExceptionServer es)
                        {
                            FrmClose();
                            throw new ExceptionServer(es.Message);
                        }
                    }
                }

                // prihvacena razmena
                if (dgv.Name == "dgvPrihvacenaRazmena")
                {
                    if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        try
                        {
                            // zavrsi razmenu
                            if (e.ColumnIndex == 6)
                            {
                                if (MessageBox.Show("Da li želite da završite razmenu?", "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    prihvacenaRazmena[e.RowIndex].PotvrdaRazmene = false;
                                    prihvacenaRazmena[e.RowIndex].ZavrsenaRazmena = true;
                                    if (Komunikacija.Instance.PotvrdaRazmeneRobe(prihvacenaRazmena[e.RowIndex], true))
                                    {
                                        zavrsenaRazmena.Add(prihvacenaRazmena[e.RowIndex]);
                                        prihvacenaRazmena.Remove(prihvacenaRazmena[e.RowIndex]);
                                        MessageBox.Show($"Uspešno završena razmena!");
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Neuspešno završena razmena!");
                                    }
                                }
                            }
                            // ponistiti razmenu
                            if (e.ColumnIndex == 7)
                            {
                                if (MessageBox.Show("Da li želite da poništite razmenu?", "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    prihvacenaRazmena[e.RowIndex].PotvrdaRazmene = false;
                                    if (Komunikacija.Instance.PonistiRazmenuRobe(prihvacenaRazmena[e.RowIndex]))
                                    {
                                        odbijenaRazmena.Add(prihvacenaRazmena[e.RowIndex]);
                                        prihvacenaRazmena.Remove(prihvacenaRazmena[e.RowIndex]);
                                        MessageBox.Show($"Uspešno poništena razmena!");
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Neuspešno poništena razmena!");
                                    }
                                }
                            }
                            // pdf jedne razmene
                            if (e.ColumnIndex == 8)
                            {
                                exportRowToPdf(trazenaRoba[e.RowIndex], "Izveštaj");
                                MessageBox.Show($"Uspešno sačuvan PDF!");
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
                if (dgv.Name == "dgvOdbijenaRazmena")
                {
                    if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        try
                        {
                            // arhiviraj razmenu
                            if (e.ColumnIndex == 6)
                            {
                                if (MessageBox.Show("Da li želite da arhivirate razmenu?", "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    odbijenaRazmena[e.RowIndex].ArhiviranaRazmena = true;
                                    if (Komunikacija.Instance.PotvrdaRazmeneRobe(odbijenaRazmena[e.RowIndex], true))
                                    {
                                        arhiviranaRazmena.Add(odbijenaRazmena[e.RowIndex]);
                                        odbijenaRazmena.Remove(odbijenaRazmena[e.RowIndex]);
                                        MessageBox.Show($"Uspešno arhivirana razmena!");
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Neuspešno arhivirana razmena!");
                                    }
                                }
                            }
                            // pdf jedne razmene
                            if (e.ColumnIndex == 7)
                            {
                                exportRowToPdf(trazenaRoba[e.RowIndex], "Izveštaj");
                                MessageBox.Show($"Uspešno sačuvan PDF!");
                            }
                        }
                        catch (ExceptionServer es)
                        {
                            FrmClose();
                            throw new ExceptionServer(es.Message);
                        }
                    }
                }

                // zavrsena razmena
                if (dgv.Name == "dgvZavrsenaRazmena")
                {
                    if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        try
                        {
                            // arhiviraj razmenu
                            if (e.ColumnIndex == 6)
                            {
                                if (MessageBox.Show("Da li želite da arhivirate razmenu?", "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    zavrsenaRazmena[e.RowIndex].ArhiviranaRazmena = true;
                                    if (Komunikacija.Instance.PotvrdaRazmeneRobe(zavrsenaRazmena[e.RowIndex], true))
                                    {
                                        arhiviranaRazmena.Add(zavrsenaRazmena[e.RowIndex]);
                                        zavrsenaRazmena.Remove(zavrsenaRazmena[e.RowIndex]);
                                        MessageBox.Show($"Uspešno arhivirana razmena!");
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Neuspešno arhivirana razmena!");
                                    }
                                }
                            }
                            // pdf jedne razmene
                            if (e.ColumnIndex == 7)
                            {
                                exportRowToPdf(trazenaRoba[e.RowIndex], "Izveštaj");
                                MessageBox.Show($"Uspešno sačuvan PDF!");
                            }
                        }
                        catch (ExceptionServer es)
                        {
                            FrmClose();
                            throw new ExceptionServer(es.Message);
                        }
                    }
                }

                // arhivirana razmena
                if (dgv.Name == "dgvArhiviranaRazmena")
                {
                    if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        try
                        {
                            // obrisi razmenu
                            if (e.ColumnIndex == 6)
                            {
                                if (MessageBox.Show("Da li želite da obrišete razmenu?", "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    arhiviranaRazmena[e.RowIndex].ArhiviranaRazmena = true;
                                    if (Komunikacija.Instance.ObrisiRazmenuRobe(arhiviranaRazmena[e.RowIndex]))
                                    {
                                        arhiviranaRazmena.Remove(arhiviranaRazmena[e.RowIndex]);
                                        MessageBox.Show($"Uspešno obrisana razmena!");
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Neuspešno obrisana razmena!");
                                    }
                                }
                            }
                            // pdf jedne razmene
                            if (e.ColumnIndex == 7)
                            {
                                exportRowToPdf(trazenaRoba[e.RowIndex], "Izveštaj");
                                MessageBox.Show($"Uspešno sačuvan PDF!");
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
        }

        // export to pdf
        internal void exportGridToPdf(DataGridView dgvRazmena, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            //
            PdfPTable pdfTable = new PdfPTable(dgvRazmena.Columns.Count - 3); 
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
            foreach(RazmenaRobe r in data)
            {
                pdfTable.AddCell(new Phrase(r.TrazenaRoba.NazivRobe, text));
                pdfTable.AddCell(new Phrase(r.KolicinaRobe.ToString() + "g", text));
                pdfTable.AddCell(new Phrase(r.DatumRazmeneRobe.ToString("dd/MM/yyyy"), text));
                pdfTable.AddCell(new Phrase(r.KorisnikTrazeneRobe.ToString(), text));
                pdfTable.AddCell(new Phrase(r.KorisnikUlozeneRobe.ToString(), text));
                pdfTable.AddCell(new Phrase(r.UlozenaRobaString, text));
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

                    Paragraph parag3 = new Paragraph("Datum izveštaja: " + DateTime.Now.ToString("dd.MM.yyyy"), font);
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

        // export to pdf 2
        internal void exportRowToPdf(RazmenaRobe razmena, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);

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
                    Font fontForLine = FontFactory.GetFont(Font.FontFamily.TIMES_ROMAN.ToString(), 20, Font.UNDERLINE, BaseColor.BLACK);

                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    System.Drawing.Image image1 = System.Drawing.Image.FromFile("C://Users/Nemanja/Desktop/NRCompar.png");
                    Image iTextImage1 = Image.GetInstance(image1, System.Drawing.Imaging.ImageFormat.Png);
                    iTextImage1.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(iTextImage1);

                    Paragraph parag1 = new Paragraph("IZVEŠTAJ RAZMENE", fontTitle);
                    parag1.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(parag1);
                    pdfDoc.Add(new Paragraph("Datum podnošenja razmene: " + razmena.DatumRazmeneRobe.ToString("dd.MM.yyyy"), font));

                    PdfPCell cel1;
                    PdfPCell cel2;
                    PdfPCell cel3;
                    PdfPCell cel4;
                    PdfPCell cel5;
                    PdfPTable table;
                    PdfPTable t2;

                    // detalji Trazene robe
                    {
                        Paragraph parTrazeneRobe = new Paragraph("Detalji korisnika Tražene robe:", font);
                        parTrazeneRobe.SpacingAfter = 5;
                        pdfDoc.Add(parTrazeneRobe);

                        table = new PdfPTable(1);

                        cel1 = new PdfPCell(new Phrase("Korisnik: " + razmena.KorisnikTrazeneRobe.ImeKorisnika + " " + razmena.KorisnikTrazeneRobe.PrezimeKorisnika, font));
                        cel2 = new PdfPCell(new Phrase("Adresa: " + razmena.KorisnikTrazeneRobe.Adresa + ", " + razmena.KorisnikTrazeneRobe.Lokacija.NazivOpstine, font));
                        cel3 = new PdfPCell(new Phrase("Tražena roba: " + razmena.TrazenaRoba.NazivRobe, font));
                        cel4 = new PdfPCell(new Phrase("Količina tražene robe: " + razmena.TrazenaRoba.KolicinaRobe + "g", font));
                        cel5 = new PdfPCell(new Phrase("Broj telefona: " + razmena.KorisnikTrazeneRobe.BrojTelefona, font));

                        cel1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                        cel2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                        cel3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                        cel4.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                        cel5.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

                        cel1.Border = Rectangle.NO_BORDER;
                        cel2.Border = Rectangle.NO_BORDER;
                        cel3.Border = Rectangle.NO_BORDER;
                        cel4.Border = Rectangle.NO_BORDER;
                        cel5.Border = Rectangle.NO_BORDER;

                        table.AddCell(cel1);
                        table.AddCell(cel2);
                        table.AddCell(cel3);
                        table.AddCell(cel4);
                        table.AddCell(cel5);

                        table.SpacingAfter = 20;
                        table.SpacingBefore = 10;

                        t2 = new PdfPTable(1);
                        t2.AddCell(table);
                        pdfDoc.Add(t2);
                    }

                    // detalji Ulozene robe
                    {
                        Paragraph parUlozeneRobe = new Paragraph("Detalji korisnika Uložene robe:", font);
                        parUlozeneRobe.SpacingAfter = 5;
                        pdfDoc.Add(parUlozeneRobe);

                        table = new PdfPTable(1);

                        cel1 = new PdfPCell(new Phrase("Korisnik: " + Sesija.Instance.Korisnik.ImeKorisnika + " " + Sesija.Instance.Korisnik.PrezimeKorisnika, font));
                        cel2 = new PdfPCell(new Phrase("Adresa: " + Sesija.Instance.Korisnik.Adresa + ", " + Sesija.Instance.Korisnik.Lokacija.NazivOpstine, font));
                        cel3 = new PdfPCell(new Phrase("Uložene roba: " + razmena.UlozenaRobaString.Replace("\n", " "), font));
                        cel4 = new PdfPCell(new Phrase("Broj telefona: " + Sesija.Instance.Korisnik.BrojTelefona, font));

                        cel1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                        cel2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                        cel3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                        cel4.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

                        cel1.Border = Rectangle.NO_BORDER;
                        cel2.Border = Rectangle.NO_BORDER;
                        cel3.Border = Rectangle.NO_BORDER;
                        cel4.Border = Rectangle.NO_BORDER;

                        table.AddCell(cel1);
                        table.AddCell(cel2);
                        table.AddCell(cel3);
                        table.AddCell(cel4);

                        table.SpacingAfter = 20;
                        table.SpacingBefore = 10;

                        t2 = new PdfPTable(1);
                        t2.AddCell(table);
                        pdfDoc.Add(t2);
                    }

                    // potpisi
                    pdfDoc.Add(new Paragraph("                    ", fontForLine));

                    pdfDoc.Add(new Paragraph(" "));

                    pdfDoc.AddAuthor(Sesija.Instance.Korisnik.ImeKorisnika + " " + Sesija.Instance.Korisnik.PrezimeKorisnika);

                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }

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

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

        // end
        internal void SrediFormu(string title, DataGridView dgvRazmena, Label lblTitle)
        {
            try
            {
                // Razmena in - end
                if (title == "RAZMENA IN")
                {
                    data = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiListuRazmeneRobe(Sesija.Instance.Korisnik, "KorisnikUlozeneRobe ="));
                    dgvRazmena.DataSource = data;
                    dgvRazmena.Columns[7].Visible = false;
                    dgvRazmena.Columns[9].Visible = false;
                    
                    //Console.WriteLine();
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (data[i].PotvrdaRazmene == true) dgvRazmena.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Green;
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
                    dgvRazmena.DataSource = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiListuRazmeneRobe(Sesija.Instance.Korisnik, "KorisnikTrazeneRobe ="));

                    //dgvRazmena.Columns["Da"].

                    //DataGridViewButtonColumn buttonAccept = new DataGridViewButtonColumn();
                    //buttonAccept.Name = "Potvrdi";
                    //buttonAccept.HeaderText = "Potvrdi";
                    //buttonAccept.Text = "Potvrdi";
                    //buttonAccept.UseColumnTextForButtonValue = true; //ova linija je obavezna

                    //dgvRazmena.Columns.Add(buttonAccept);

                    for (int i = 0; i < data.Count; i++)
                    {
                        if (data[i].PotvrdaRazmene == true) dgvRazmena.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Green;
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
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
            {
                try
                {
                    if (e.ColumnIndex == 7) dgvRazmena.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Green;
                    if (e.ColumnIndex == 8) dgvRazmena.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
                catch (ExceptionServer es)
                {
                    FrmClose();
                    throw new ExceptionServer(es.Message);
                }
            }

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                try
                {
                    MessageBox.Show($"Click on button!");
                    if(e.ColumnIndex == 9)
                    {
                        if(Komunikacija.Instance.PotvrdaRazmeneRobe(data[e.RowIndex], true))
                        {
                            MessageBox.Show($"Changed!");
                        }
                        else
                        {
                            MessageBox.Show($"Failed!");
                        } 
                    }
                }
                catch (ExceptionServer es)
                {
                    FrmClose();
                    throw new ExceptionServer(es.Message);
                }
            }
        }

        // export to pdf
        internal void exportGridToPdf(DataGridView dgvRazmena, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfTable = new PdfPTable(dgvRazmena.Columns.Count - 5);
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

                    Paragraph parag1 = new Paragraph("Izveštaj razmene", fontTitle);
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

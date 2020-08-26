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

        // end
        internal void SrediFormu(string title, DataGridView dgvRazmena, Label lblTitle)
        {
            try
            {
                // Razmena in - end
                if (title == "RAZMENA IN")
                {
                    dgvRazmena.DataSource = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiListuRazmeneRobe(Sesija.Instance.Korisnik, "KorisnikUlozeneRobe ="));
                }

                // Razmena Out - end
                if (title == "RAZMENA OUT")
                {
                    lblTitle.Text = title;
                    dgvRazmena.DataSource = new BindingList<RazmenaRobe>(Komunikacija.Instance.VratiListuRazmeneRobe(Sesija.Instance.Korisnik, "KorisnikTrazeneRobe ="));

                    //dgvRazmena.Columns["Da"].

                    //DataGridViewButtonColumn buttonAccept = new DataGridViewButtonColumn();
                    //buttonAccept.Name = "Potvrdi";
                    //buttonAccept.HeaderText = "Potvrdi";
                    //buttonAccept.Text = "Potvrdi";
                    //buttonAccept.UseColumnTextForButtonValue = true; //ova linija je obavezna

                    //dgvRazmena.Columns.Add(buttonAccept);
                }
            }
            catch (ExceptionServer es)
            {
                FrmClose();
                throw new ExceptionServer(es.Message);
            }
        }

        //
        internal void OnClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
            {
                try
                {
                    MessageBox.Show($"Click on image!");
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
            PdfPTable pdfTable = new PdfPTable(dgvRazmena.Columns.Count);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            Font text = new Font(bf, 10, Font.NORMAL);
            //Add header
            foreach(DataGridViewColumn column in dgvRazmena.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }
            //Add datarow
            foreach(DataGridViewRow row in dgvRazmena.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
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
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
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

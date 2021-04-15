using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdaja.WinUI.Korisnici
{
    public partial class frmPrikazKorisnika : Form
    {
        APIService _serviceKorisnici = new APIService("Korisnici");
        public frmPrikazKorisnika()
        {
            InitializeComponent();
            dgvKorisnici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            
            KorisniciSearchObject request = new KorisniciSearchObject()
            {
                Ime = txtIme.Text
            };
            dgvKorisnici.DataSource = await _serviceKorisnici.GetAll<List<KorisniciDto>>(request);
            dgvKorisnici.Columns["KorisnikId"].HeaderText = "Id";
            dgvKorisnici.Columns["KorisnickoIme"].HeaderText = "Korisničko ime";
        }

        private async void frmPrikazKorisnika_Load(object sender, EventArgs e)
        {
            dgvKorisnici.DataSource = await _serviceKorisnici.GetAll<List<KorisniciDto>>(null);
            dgvKorisnici.Columns["KorisnikId"].HeaderText = "Id";
            dgvKorisnici.Columns["KorisnickoIme"].HeaderText = "Korisničko ime";
        }
    }
}

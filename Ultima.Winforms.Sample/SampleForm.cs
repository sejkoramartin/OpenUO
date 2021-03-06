﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenUO.Ultima;
using OpenUO.Core.Patterns;

namespace Ultima.Winforms.Sample
{
    public partial class SampleForm : Form
    {
        private IoCContainer _container;
        private ArtworkFactory _artFactory;
        private GumpFactory _gumpFactory;
        private SoundFactory _soundFactory;

        public SampleForm(IoCContainer container)
        {
            _container = container;

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Initialize();
        }

        private void Initialize()
        {
            if (uoInstallationComboBox1.SelectedInstallation == null)
                return;

            if (_artFactory != null)
            {
                _artFactory.Dispose();
                _artFactory = null;
            }

            if(_gumpFactory != null){
                _gumpFactory.Dispose();
                _gumpFactory = null;
            }

            if (_soundFactory != null)
            {
                _soundFactory.Dispose();
                _soundFactory = null;
            }

            _gumpFactory = new GumpFactory(uoInstallationComboBox1.SelectedInstallation, _container);
            _artFactory = new ArtworkFactory(uoInstallationComboBox1.SelectedInstallation, _container);
            _soundFactory = new SoundFactory(uoInstallationComboBox1.SelectedInstallation, _container);

            artworkControl1.Factory = _artFactory;
            artworkControl2.Factory = _artFactory;
            gumpControl.Factory = _gumpFactory;
            soundControl.Factory = _soundFactory;
        }
        
        private void uoInstallationComboBox1_SelectedInstallationChanged(object sender, EventArgs e)
        {
            Initialize();
        }
    }
}

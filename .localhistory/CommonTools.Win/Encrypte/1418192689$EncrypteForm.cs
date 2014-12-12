﻿
using System.Drawing;
using System.Windows.Forms;
using CommonTools.Common;

namespace CommonTools.Win.Encrypte
{
    public partial class EncrypteForm : BaseForm
    {



        public EncrypteForm()
        {
            ApplySkin("McSkin");
            InitializeComponent();
        }

        private void EncrypteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StartForm start = new StartForm();
            start.Show();
        }

        /// <summary>
        ///  MD5加密
        /// </summary>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-12-10 11:05:50
        private void PicSubmitMd5_Click(object sender, System.EventArgs e)
        {
            string plaintext = TxtPlaintext.Text.Trim();
            string txtnumber = TxtNumber.Text.Trim();
            string ciphertext1 = TxtCiphertext1.Text.Trim();
            string ciphertext2 = TxtCiphertext2.Text.Trim();
            if (string.IsNullOrEmpty(plaintext))
            {
                MessageBox.Show("请填写明文！");
                return;
            }
            if (txtnumber.ConvertToInt() == -2 || ciphertext1.ConvertToInt() == -2 || ciphertext2.ConvertToInt() == -2)
            {
                MessageBox.Show("正确填写数字！");
                return;
            }

        }

        /// <summary>
        ///  按下事件
        /// </summary>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-12-10 13:44:01
        private void PicSubmitMd5_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Image = Properties.Resources.google_down;
        }

        /// <summary>
        ///  释放事件
        /// </summary>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-12-10 13:44:58
        private void PicSubmitMd5_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            ChangePicboxImage(Properties.Resources.google_up, pictureBox);
        }

        private void ChangePicboxImage(Image image, PictureBox pictureBox)
        {
            pictureBox.Image = image;
            pictureBox.Refresh();
        }



    }
}
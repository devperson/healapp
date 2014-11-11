using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HServer.Models.DataAccess
{    
    public class DataBaseInitializer : CreateDatabaseIfNotExists<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            #region ADDING TIP AND  TIPCATEGORIES
            //###################ADDING TIP AND  TIPCATEGORIES#######################################
            var cat1 = new TipCategory { Name = "Heart and blood circulation" };
            cat1.Tips.Add(new Tip { Name = "Healthy heart", Description="Remember that you heart is a muscle if you want it to be stronger you need to exercise it." });            
            context.TipCategories.Add(cat1);            

            var cat2 = new TipCategory { Name = "Diabetes" };
            cat2.Tips.Add(new Tip { Name = "Blood glucose testing", Description = "Recommended to have glucose monitoring equipment." });
            cat2.Tips.Add(new Tip { Name = "Blood glucose testing tips", Description = "Be sure that hand are clean" });
            cat2.Tips.Add(new Tip { Name = "Regular exercise is a must", Description = "Exercise is important for diabetics." });
            context.TipCategories.Add(cat2);            

            var cat3 = new TipCategory { Name = "Hand hygiene" };
            cat3.Tips.Add(new Tip { Name = "Always wash your hands before", Description = "Preparing food, eating… etc." });
            cat3.Tips.Add(new Tip { Name = "Always wash your hands after:", Description = "Preparing food, eating… etc." });
            cat3.Tips.Add(new Tip { Name = "How to wash your hand", Description = "Best to wash your hand with soap." });
            context.TipCategories.Add(cat3);            

            var cat4 = new TipCategory { Name = "Dental care" };
            cat4.Tips.Add(new Tip { Name = "Brushing for oral health", Description = "Oral health begins with clean teeth" });
            cat4.Tips.Add(new Tip { Name = "Other oral health tips", Description = "Use an antimicrobial mouth rinse" });
            cat4.Tips.Add(new Tip { Name = "How to wash your hand", Description = "Best to wash your hand with soap." });
            context.TipCategories.Add(cat4);
            context.SaveChanges();
            //###########################################################################################
            #endregion

            #region ADDING DOCTORS
            //###################ADDING TIP AND  TIPCATEGORIES#######################################
            Language lanEn = new Language{ Name = "English"};            
            Language lanAr = new Language { Name = "Arabic" };

            Position pSP = new Position() { Name = "Specialist Radiologist" };
            Department depCIR = new Department() { Name = "Clinical Imaging	Radiology" };
            
            Doctor doc1 = new Doctor();
            doc1.Name = "Hamad Reza Dehdashtian";
            doc1.ImageFileName = "img1.png";
            doc1.Position = pSP;
            doc1.Department = depCIR;
            doc1.Bio = "After completing his studies in Hungary, Dr. Hamad Reza worked in a large multi-disciplinary university hospital established in 1895 as a Specialist Radiologist and later as a Neuroradiologist, gaining a great deal of experience dealing with adult and Paediatric Radiology. He became a Member of The Hungarian Medical Chamber of Doctors in 2000 and has been a member of The General Medical Council (GMC) and Swedish National Board of Health and Welfare (Socialstyrelsen) since 2008. He joined the Clinical Imaging Institute at Al Ain Hospital as a Specialist Radiologist in May 2010. ";
            doc1.Qualifications.Add(new Qualification { Name = "National Board of Neuroradiology, (Neuroradiologist) Hungary" });
            doc1.Qualifications.Add(new Qualification { Name = "National Board of Radiology (Radiologist) Hungary" });
            doc1.Qualifications.Add(new Qualification { Name = "Medical Degree, Hungary" });            
            doc1.Languages.Add(lanEn);
            doc1.Languages.Add(new Language { Name = "Farsi" });
            doc1.Languages.Add(new Language { Name = "Hungari" });
            context.Doctors.Add(doc1);
            context.SaveChanges();
            
            Doctor doc2 = new Doctor();
            doc2.Name = "Ahmed Ibrahim El Bery";
            doc2.ImageFileName = "img2.png";
            doc2.Position = pSP;
            doc2.Department = depCIR;
            doc2.Bio = "After he completed his MBBch studies at Alexandria University in 1990, Dr. Ahmed joined the Radiology department in Cairo University, gaining an MSc degree in Radiology in 1998. After that, he completed his studies at The Royal College of Radiologists, London to get an FRCR degree in 2007 before joining Al Ain Hospital as a Specialist Radiologist in 2008.";            
            doc2.Qualifications.Add(new Qualification { Name = "MBBch, MSC in Radiology, FRCR - London" });                  
            doc2.Languages.Add(lanEn);            
            doc2.Languages.Add(lanAr);
            context.Doctors.Add(doc2);
            context.SaveChanges();
            
            Department depMI = new Department() { Name = "Medical Institute" };            
            Doctor doc3 = new Doctor();
            doc3.Name = "Mohammed Ali Abdelsamad Hussein";
            doc3.ImageFileName = "img3.png";
            doc3.Position = new Position() { Name = "Specialist Cardiologist" };
            doc3.Department = depMI;
            doc3.SubDepartment = new SubDepartment() { Name = "Cardiology"};
            doc3.Bio = "Dr. Mohammed graduated from Ain Shams University, Egypt in 1986 and finished his house officer training in the university hospital before joining PHC for 18 months. From 1990 – 1994 he had a residency in the National Heart Institute in Cairo where he became an assistant specialist and later, a specialist there until 2002. He then worked as an Echo Specialist in Hamad Medical Corporation, Qatar until 2004 and as a specialist cardiologist in Khamis Mushait Armed hospital, Abha, KSA until 2006. He has been working at Al Ain Hospital as a Specialist Cardiologist since 2006.";            
            doc3.Qualifications.Add(new Qualification { Name = "MBBch, Master Degree in Cardiology and PhD in Cardiology, Ain Shams University, Cairo, Egypt." });            
            doc3.Qualifications.Add(new Qualification { Name = "Fellowship in Interventional Cardiology at National Cardiovascular Center, Osaka, Japan." });            
            doc3.Languages.Add(lanEn);
            doc3.Languages.Add(lanAr);
            context.Doctors.Add(doc3);
            context.SaveChanges();
                        
            Doctor doc4 = new Doctor();
            doc4.Name = "Ghassan Atta";
            doc4.ImageFileName = "img4.png";
            doc4.Position = new Position() { Name = "Specialist Neurologist" };
            doc4.Department = depMI;
            doc4.SubDepartment = new SubDepartment() { Name = "Neurology"}; 
            doc4.Bio = "Dr. Ghassan joined Al Ain Hospital during 2009, after three years as a specialist neurologist at NMC Speciality Hospitals in Dubai, Abu Dhabi and Al Ain. He came to the UAE in 2006 from England following additional training courses during 2005-2006. Before this, he was working as a specialist neurologist and university teacher in Iraq at Al Kindy Teaching Hospital/Medical College - Baghdad University.";            
            doc4.Qualifications.Add(new Qualification { Name = "FICMS (neurology board) - 2002." });
            doc4.Qualifications.Add(new Qualification { Name = "MBChB (Iraqi Medical College) - 1994." });
            doc4.Languages.Add(lanEn);
            doc4.Languages.Add(lanAr);
            context.Doctors.Add(doc4);
            context.SaveChanges();

            
            Doctor doc5 = new Doctor();
            doc5.Name = "John Behrendt";
            doc5.ImageFileName = "img5.png";
            doc5.Position = new Position() { Name = "Consultant Gastroenerologist" };
            doc5.Department = depMI;
            doc5.SubDepartment = new SubDepartment() { Name = "Gastroenterology & Hepatology"}; 
            doc5.Bio = "After working in different hospitals in Germany for more than 22 years, Dr. John was ready for a new challenge. He joined Al Ain Hospital in September 2009 to work in the Department for Gastroenterology and Hepatology.	";            
            doc5.Qualifications.Add(new Qualification { Name = "Graduate Doctor from Medical College at Free University, Berlin, Germany. " });
            doc5.Qualifications.Add(new Qualification { Name = "Board of Internal Medicine, Nordrhein, Westfalia, Germany. " });
            doc5.Qualifications.Add(new Qualification { Name = "Board of Vascular Medicine in Internal Medicine, Berlin, Germany. " });
            doc5.Languages.Add(lanEn);
            doc5.Languages.Add(new Language { Name = "German" });
            doc5.Languages.Add(new Language { Name = "French" });
            context.Doctors.Add(doc5);
            
            context.SaveChanges();
            //###########################################################################################
            #endregion
        }
    }
}
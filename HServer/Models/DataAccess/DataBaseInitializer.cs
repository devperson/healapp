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
            cat1.Tips.Add(new Tip { Name = "Healthy heart", Description = "Remember that you heart is a muscle if you want it to be stronger you need to exercise it." });
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
            Language lanEn = new Language { Name = "English" };
            Language lanAr = new Language { Name = "Arabic" };

            Position pSP = new Position() { Name = "Specialist Radiologist" };
            Department depCIR = new Department() { Name = "Clinical Imaging	Radiology" };

            Doctor doc1 = new Doctor();
            doc1.Name = "Hamad Reza Dehdashtian";
            doc1.ImageFileName = "img1.jpg";
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
            doc2.ImageFileName = "img2.jpg";
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
            doc3.ImageFileName = "img3.jpg";
            doc3.Position = new Position() { Name = "Specialist Cardiologist" };
            doc3.Department = depMI;
            doc3.SubDepartment = new SubDepartment() { Name = "Cardiology" };
            doc3.Bio = "Dr. Mohammed graduated from Ain Shams University, Egypt in 1986 and finished his house officer training in the university hospital before joining PHC for 18 months. From 1990 – 1994 he had a residency in the National Heart Institute in Cairo where he became an assistant specialist and later, a specialist there until 2002. He then worked as an Echo Specialist in Hamad Medical Corporation, Qatar until 2004 and as a specialist cardiologist in Khamis Mushait Armed hospital, Abha, KSA until 2006. He has been working at Al Ain Hospital as a Specialist Cardiologist since 2006.";
            doc3.Qualifications.Add(new Qualification { Name = "MBBch, Master Degree in Cardiology and PhD in Cardiology, Ain Shams University, Cairo, Egypt." });
            doc3.Qualifications.Add(new Qualification { Name = "Fellowship in Interventional Cardiology at National Cardiovascular Center, Osaka, Japan." });
            doc3.Languages.Add(lanEn);
            doc3.Languages.Add(lanAr);
            context.Doctors.Add(doc3);
            context.SaveChanges();

            Doctor doc4 = new Doctor();
            doc4.Name = "Ghassan Atta";
            doc4.ImageFileName = "img4.jpg";
            doc4.Position = new Position() { Name = "Specialist Neurologist" };
            doc4.Department = depMI;
            doc4.SubDepartment = new SubDepartment() { Name = "Neurology" };
            doc4.Bio = "Dr. Ghassan joined Al Ain Hospital during 2009, after three years as a specialist neurologist at NMC Speciality Hospitals in Dubai, Abu Dhabi and Al Ain. He came to the UAE in 2006 from England following additional training courses during 2005-2006. Before this, he was working as a specialist neurologist and university teacher in Iraq at Al Kindy Teaching Hospital/Medical College - Baghdad University.";
            doc4.Qualifications.Add(new Qualification { Name = "FICMS (neurology board) - 2002." });
            doc4.Qualifications.Add(new Qualification { Name = "MBChB (Iraqi Medical College) - 1994." });
            doc4.Languages.Add(lanEn);
            doc4.Languages.Add(lanAr);
            context.Doctors.Add(doc4);
            context.SaveChanges();


            Doctor doc5 = new Doctor();
            doc5.Name = "John Behrendt";
            doc5.ImageFileName = "img5.jpg";
            doc5.Position = new Position() { Name = "Consultant Gastroenerologist" };
            doc5.Department = depMI;
            doc5.SubDepartment = new SubDepartment() { Name = "Gastroenterology & Hepatology" };
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

            #region ADDING FAQS
            //###################ADDING FAQS#######################################
            Faq f1 = new Faq();
            f1.Question = "Q1";
            f1.Answer = "Answer 1";
            context.Faqs.Add(f1);

            Faq f2 = new Faq();
            f2.Question = "Q2";
            f2.Answer = "Answer 2";
            context.Faqs.Add(f2);

            Faq f3 = new Faq();
            f3.Question = "Q2";
            f3.Answer = "Answer 3";
            context.Faqs.Add(f3);

            context.SaveChanges();
            //#####################################################################
            #endregion

            #region ADDING Insurance
            //###################ADDING Insurence#######################################
            Insurance in1 = new Insurance();
            in1.Title = "ADNIC";
            in1.Description = "Only Platinum";
            context.Insurances.Add(in1);

            Insurance in2 = new Insurance();
            in2.Title = "Al Hilal takaful";
            in2.Description = "GN + SEHA & CN + SEHA";
            context.Insurances.Add(in2);

            Insurance in3 = new Insurance();
            in3.Title = "SAICO";
            in3.Description = "Open Network";
            context.Insurances.Add(in3);

            context.SaveChanges();
            //#####################################################################
            #endregion

            #region ADDING News
            //###################ADDING Insurence#######################################
            News n1 = new News();
            n1.Date = new DateTime(2014, 3, 9);
            n1.Title = "Al Ain Hospital launches UAE’s first specialised Children’s Rheumatology Clinic";
            n1.Description = @"Al Ain Hospital, owned and operated by Abu Dhabi Health Services Company PJSC (SEHA), has launched the nation’s first Paediatric Rheumatology Clinic.
“We had a soft internal launch in October 2013, but now we are fully geared to handle the large volumes of  child patients expected from across the country as we are the only hospital in the UAE that has a specialised rheumatology department for children,” emphasised Dr. Elsadeg Mohamed Sharif, consultant paediatrician at Al Ain Hospital’s Paediatric Rheumatology Clinic.
The Clinic is a “one-stop facility” offering the entire spectrum of treatment modalities – from diagnosis to advanced treatment including the usage of biologics which are protein-based drugs derived from living organisms cultured in a laboratory.
Patients also have access to allied services including excellent radiology, anaesthetic and paediatric ophthalmology care.
 “Prior to the launch of this Clinic children with rheumatological problems have been under the care of adult rheumatologists, but now patients have the advantage of being
 
treated by doctors who have dual speciality in paediatrics and rheumatology,” added Dr. Sharif.
The most common ailment that comes under the purview of paediatric rheumatology is juvenile idiopathic arthritis, also known as juvenile rheumatoid arthritis, which  causes the inflation of the joints. This the most prevalent form of arthritis in children and adolescents.
Other common complaints are Familial Mediterranean Fever which is a hereditary inflammation disease and Systemic Lupus Erythematosus, commonly known as SLE or lupus, which is a disease  that can affect any part of the body. As in other autoimmune diseases, the immune system attacks the body's cells and tissue, resulting in inflammation and tissue damage.
“To combat these diseases we use some latest, state-of-the-art treatment modalities at our clinic, including intra-articular corticosteroid injection, methotrexate subcutaneous  injection and biologic drug injection,” explained Rd. Sharif.
Intra-articular corticosteroids or steroids are medicines injected directly into the joint space of a painful, inflamed arthritic joint. Steroids which are similar to natural substances produced by the body (hormones) help reduce inflammation.
Methotrexate subcutaneous injection involves injecting the drug into the fatty layer of tissue under the skin. Biologic drug injection uses biologics, which include medicinal products such as vaccines, blood or blood component, tissue, living cells etc. created by biological processes and not chemically synthesised, that are used as therapeutics to treat diseases.  
 
“With the launch we expect to provide excellent care to about 10 – 12 patients a day at the Clinic which is located in Al Ain Hospital complex,” explained Dr. Sharif.
“Among our plans for future are the development of  physiotherapy and occupational therapy services and establishing outreach clinics,” outlined Dr. Sharif.";
            context.News.Add(n1);

            News n2 = new News();
            n2.Date = new DateTime(2012, 6, 28);
            n2.Title = "Al Ain Hospital Expands Internal Medicine Facilities";
            n2.Description = @"Al Ain Hospital, owned and operated by Abu Dhabi Health Services Company PJSC (SEHA) and managed by Medical University of Vienna and VAMED, today announced renewing and expanding its internal medicine consultancy practice to serve the rising number of patients to its specialist clinics.
In a statement, the hospital said that in its continuing endeavor to serve the Al Ain community better with enhanced standards of medical facilities, it has added 122 more beds to its internal medicine facilities and increased the number of consultancy clinics to 20, adding four new units. 
The four new clinics under the Internal Medical Institute include consultancies in diabetics, ENT, foot care and eye care. Apart from these clinics, the Internal Medical Institute is also offering advisory on healthy eating habits and behavioral changes for diabetic patients.
The hospital said the clinics under the ambit of the Internal Medical Institute receive some 67,000 patients a year and enhancing the facilities and standards will help the healthcare body serve the community better.
Mr. George Jepson, CEO of Al Ain Hospital said:”.Our aim and mandate is to provide complete medical consultancy services and expert treatment facilities to the UAE nationals and expats. We have best-in-class internal medicine clinics with cutting-edge expertise across various disciplines to serve the community better.”
Dr. Talaat Diab, Consultant, Internal Medicine and Deputy Director of Al Ain Hospital’s Internal Medical Institute said that the new developments including new disciplines and services at higher standards were a great achievement which will add value to the hospital’s positioning as a community-focused healthcare institute.
“We are proud of these new developments and these enhancements at the Internal Medical Institute have come in the context of rising number of patients to the clinics. In the last five months alone, we received some 32,000 patients in our internal medicine clinics,” he said.";
            context.News.Add(n2);

            News n3 = new News();
            n3.Date = new DateTime(2008, 4, 1);
            n3.Title = "Opening Professorial Medical Unit";
            n3.Description = @"Goal
 The primary goal of the PMU is to provide a role model for clinical care in an academic environment, with components of expertise in clinical service, education and teaching of resident doctors, interns and students. This is based on the philosophy that excellence in patient care is best achieved when delivered in an atmosphere of enquiry, debate and teaching.

 Mechanisms Of Delivery Of Care

The PMU cooperates with the other Medical Units in the Medical Institute in the acute on-call and in-patient care of severely ill patients, working under the clinical leadership of a Consultant Physician certified by the FMHS Internal Medicine Board. This consultant is supported by an experienced AAH Specialist in Internal Medicine with an adjunct academic appointment at FMHS, a Resident from the Al Ain Medical District Residency Training Programme (Arab Board-accredited), as well as an intern and medical students.
 The PMU staff takes part in the department-wide morning report and contributes to the hospital’s CME and other educational activities.  Teaching rounds led by the FMHS consultant are conducted daily on PMU patients.
 A dedicated PMU out-patient clinic provides continuity of care for patients discharged from the in-patient PMU facility.  In addition to on-call admissions, the FMHS Internal Consultant Physicians also admit patients directly to PMU for work up, diagnosis and management.
 All of the FMHS Internal Consultant Physicians admit patients directly to PMU in addition to on-call admissions, for work up, diagnosis and management.

 Teaching
 In addition to clinical care, the weekly PMU teaching activities include ‘the case of the week’, the discussion of journal articles, and a clinical-radiological conference. The PMU has a dedicated teaching room with a-v facilities and internet access. The Faculty-led morning report for medical students is held daily and residents also attend a dedicated academic half-day at the FMHS under the direction of the Programmer Directors.

 Research
 The PMU has a dedicated Research Office for conducting clinical trials and other research, both of which are actively ongoing.
 Assessment, Aduit, Guidelines
 Audits are undertaken to ascertain patient satisfaction and quality of care in various areas such as antimicrobial prescribing, and clinical pathways for selected medical emergencies are also being prepared.
";
            context.News.Add(n3);

            context.SaveChanges();
            //#####################################################################
            #endregion

            #region ADDING CME
            context.Cmes.Add(new Cme()
            {
                Title = "sadfdsag",
                Date = DateTime.Now,
                Description = "dsfgdfsg fhfsgsdff sadfdsa fgfsh fg hsd safsd fsda fsda fd gdf",
                Speaker = "sdfasdf",
                Venue = "sadfsda gdfs gdfgfdsg ds",
                CreditHours = "1h"
            });

            context.Cmes.Add(new Cme()
            {
                Title = "sadfdsag",
                Date = DateTime.Now.AddDays(1),
                Description = "dsfgdfsg fhfsgsdff sadfdsa fgfsh fg hsd safsd fsda fsda fd gdf",
                Speaker = "sdfasdf",
                Venue = "sadfsda gdfs gdfgfdsg ds",
                CreditHours = "1h"
            });

            context.SaveChanges();
            //#####################################################################
            #endregion

            #region ADDING Events
            context.Events.Add(new Event()
            {
                Title = "Event1",
                Date = DateTime.Now,
                Description = "adsg fd gdf gdsfg sdf gsdf gsdfg dsf",
                Venue = "hndfsd gdsf gdsf gfds gfds gsdf gds"
            });

            context.Events.Add(new Event()
            {
                Title = "Event2",
                Date = DateTime.Now,
                Description = "adsg fd gdf gdsfg sdf gsdf gsdfg dsf",
                Venue = "hndfsd gdsf gdsf gfds gfds gsdf gds"
            });

            context.Events.Add(new Event()
            {
                Title = "Event3",
                Date = DateTime.Now,
                Description = "adsg fd gdf gdsfg sdf gsdf gsdfg dsf",
                Venue = "hndfsd gdsf gdsf gfds gfds gsdf gds"
            });

            context.Events.Add(new Event()
            {
                Title = "Event4",
                Date = DateTime.Now,
                Description = "adsg fd gdf gdsfg sdf gsdf gsdfg dsf",
                Venue = "hndfsd gdsf gdsf gfds gfds gsdf gds"
            });
            #endregion
        }
    }
}
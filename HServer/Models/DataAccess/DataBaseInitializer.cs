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
            var arabicLocal = new LocalizationLanguage() { Name = "Ar" };
            var englishLocal = new LocalizationLanguage() { Name = "En" };

            #region ADDING TIP AND  TIPCATEGORIES
            //####################ADDING TIP AND  TIPCATEGORIES#######################################
            //Cat1
            var enCat = new TipCategoryLocalization();
            enCat.Localization = englishLocal;
            enCat.Name = "Heart and blood circulation";            
            var arCat = new TipCategoryLocalization();
            arCat.Localization = arabicLocal;
            arCat.Name = "القلب والدورة الدموية";            
            var cat1 = new TipCategory();
            cat1.Localizations.Add(enCat);
            cat1.Localizations.Add(arCat);
            var enTip = new TipLocalization();
            enTip.Localization = englishLocal;
            enTip.Name = "Healthy heart";
            enTip.Description = "Remember that you heart is a muscle if you want it to be stronger you need to exercise it.";
            var arTip = new TipLocalization();
            arTip.Localization = arabicLocal;
            arTip.Name = "صحة القلب";
            arTip.Description = "تذكر أنك القلب عبارة عن عضلة إذا كنت تريد أن تكون أقوى تحتاج إلى ممارسة هذا الحق.";
            var tip = new Tip();
            tip.Localizations.Add(enTip);
            tip.Localizations.Add(arTip);
            cat1.Tips.Add(tip);
            context.TipCategories.Add(cat1);

            //Cat2
            enCat = new TipCategoryLocalization();
            enCat.Localization = englishLocal;
            enCat.Name = "Diabetes";
            arCat = new TipCategoryLocalization();
            arCat.Localization = arabicLocal;
            arCat.Name = "مرض السكري";
            var cat2 = new TipCategory();
            cat2.Localizations.Add(enCat);
            cat2.Localizations.Add(arCat);
            //tip
            enTip = new TipLocalization();
            enTip.Localization = englishLocal;
            enTip.Name = "Blood glucose testing";
            enTip.Description = "Recommended to have glucose monitoring equipment.";
            arTip = new TipLocalization();
            arTip.Localization = arabicLocal;
            arTip.Name = "اختبار السكر في الدم";
            arTip.Description = "وأوصت لدينا معدات مراقبة الجلوكوز.";
            tip = new Tip();
            tip.Localizations.Add(enTip);
            tip.Localizations.Add(arTip);
            cat2.Tips.Add(tip);
            //tip
            enTip = new TipLocalization();
            enTip.Localization = englishLocal;
            enTip.Name = "Blood glucose testing tips";
            enTip.Description = "Be sure that hand are clean";
            arTip = new TipLocalization();
            arTip.Localization = arabicLocal;
            arTip.Name = "السكر في الدم نصائح الاختبار";
            arTip.Description = "مما لا شك فيه أن اليد نظيفة";
            tip = new Tip();
            tip.Localizations.Add(enTip);
            tip.Localizations.Add(arTip);
            cat2.Tips.Add(tip);
            //tip
            enTip = new TipLocalization();
            enTip.Localization = englishLocal;
            enTip.Name = "Regular exercise is a must";
            enTip.Description = "Exercise is important for diabetics.";
            arTip = new TipLocalization();
            arTip.Localization = arabicLocal;
            arTip.Name = "ممارسة التمارين الرياضية بانتظام أمر لا بد منه";
            arTip.Description = "ممارسة مهم لمرضى السكر.";
            tip = new Tip();
            tip.Localizations.Add(enTip);
            tip.Localizations.Add(arTip);
            cat2.Tips.Add(tip);
            context.TipCategories.Add(cat2);

            //Cat3
            enCat = new TipCategoryLocalization();
            enCat.Localization = englishLocal;
            enCat.Name = "Hand hygiene";
            arCat = new TipCategoryLocalization();
            arCat.Localization = arabicLocal;
            arCat.Name = "نظافة اليدين";
            var cat3 = new TipCategory();
            cat3.Localizations.Add(enCat);
            cat3.Localizations.Add(arCat);
            //tip
            enTip = new TipLocalization();
            enTip.Localization = englishLocal;
            enTip.Name = "Always wash your hands before";
            enTip.Description = "Preparing food, eating… etc.";
            arTip = new TipLocalization();
            arTip.Localization = arabicLocal;
            arTip.Name = "اغسل يديك دائما قبل";
            arTip.Description = "إعداد الطعام، وتناول الطعام ... الخ";
            tip = new Tip();
            tip.Localizations.Add(enTip);
            tip.Localizations.Add(arTip);
            cat3.Tips.Add(tip);
            //tip
            enTip = new TipLocalization();
            enTip.Localization = englishLocal;
            enTip.Name = "Always wash your hands after:";
            enTip.Description = "Preparing food, eating… etc.";
            arTip = new TipLocalization();
            arTip.Localization = arabicLocal;
            arTip.Name = "تغسل يديك دائما بعد:";
            arTip.Description = "إعداد الطعام، وتناول الطعام ... الخ";
            tip = new Tip();
            tip.Localizations.Add(enTip);
            tip.Localizations.Add(arTip);
            cat3.Tips.Add(tip);
            //tip
            enTip = new TipLocalization();
            enTip.Localization = englishLocal;
            enTip.Name = "How to wash your hand";
            enTip.Description = "Best to wash your hand with soap.";
            arTip = new TipLocalization();
            arTip.Localization = arabicLocal;
            arTip.Name = "كيفية غسل يدك";
            arTip.Description = "أفضل لغسل يدك بالماء والصابون.";
            tip = new Tip();
            tip.Localizations.Add(enTip);
            tip.Localizations.Add(arTip);
            cat3.Tips.Add(tip);
            context.TipCategories.Add(cat3);


            //Cat4
            enCat = new TipCategoryLocalization();
            enCat.Localization = englishLocal;
            enCat.Name = "Dental care";
            arCat = new TipCategoryLocalization();
            arCat.Localization = arabicLocal;
            arCat.Name = "العناية بالأسنان";
            var cat4 = new TipCategory();
            cat4.Localizations.Add(enCat);
            cat4.Localizations.Add(arCat);
            //tip
            enTip = new TipLocalization();
            enTip.Localization = englishLocal;
            enTip.Name = "Brushing for oral health";
            enTip.Description = "Oral health begins with clean teeth";
            arTip = new TipLocalization();
            arTip.Localization = arabicLocal;
            arTip.Name = "تنظيف الأسنان بالفرشاة لصحة الفم والأسنان";
            arTip.Description = "تبدأ صحة الفم مع الأسنان نظيفة";
            tip = new Tip();
            tip.Localizations.Add(enTip);
            tip.Localizations.Add(arTip);
            cat4.Tips.Add(tip);
            //tip2
            enTip = new TipLocalization();
            enTip.Localization = englishLocal;
            enTip.Name = "Other oral health tips";
            enTip.Description = "Use an antimicrobial mouth rinse";
            arTip = new TipLocalization();
            arTip.Localization = arabicLocal;
            arTip.Name = "نصائح صحة الفم الأخرى";
            arTip.Description = "استخدام شطف الفم المضادة للجراثيم";
            tip = new Tip();
            tip.Localizations.Add(enTip);
            tip.Localizations.Add(arTip);
            cat4.Tips.Add(tip);
            //tip3
            enTip = new TipLocalization();
            enTip.Localization = englishLocal;
            enTip.Name = "How to wash your hand";
            enTip.Description = "Best to wash your hand with soap.";
            arTip = new TipLocalization();
            arTip.Localization = arabicLocal;
            arTip.Name = "كيفية غسل يدك";
            arTip.Description = "أفضل لغسل يدك بالماء والصابون.";
            tip = new Tip();
            tip.Localizations.Add(enTip);
            tip.Localizations.Add(arTip);
            cat4.Tips.Add(tip);
            context.TipCategories.Add(cat4);          
            context.SaveChanges();
            //###########################################################################################
            #endregion

            #region ADDING DOCTORS
            //###################ADDING TIP AND  TIPCATEGORIES#######################################
            //Lan1            
            var lanEn = this.GetLanguage("English", "الإنجليزية", englishLocal, arabicLocal);
            var lanAr = this.GetLanguage("Arabic", "العربية", englishLocal, arabicLocal);
            
            //Pos            
            var pSP = this.GetPosision("Specialist Radiologist", "أشعة متخصص", englishLocal, arabicLocal);
            var depCIR = this.GetDepartment("Clinical Imaging Radiology", "السريرية التصوير الإشعاعي", englishLocal, arabicLocal);                                  
            
            //Doc1
            var doc1 = this.GetDoctorObject("Hamad Reza Dehdashtian", 
                                            "After completing his studies in Hungary, Dr. Hamad Reza worked in a large multi-disciplinary university hospital established in 1895 as a Specialist Radiologist and later as a Neuroradiologist, gaining a great deal of experience dealing with adult and Paediatric Radiology. He became a Member of The Hungarian Medical Chamber of Doctors in 2000 and has been a member of The General Medical Council (GMC) and Swedish National Board of Health and Welfare (Socialstyrelsen) since 2008. He joined the Clinical Imaging Institute at Al Ain Hospital as a Specialist Radiologist in May 2010. ",
                                            "حمد رضا", 
                                            "بعد الانتهاء من دراسته في المجر، عمل الدكتور حمد رضا في مستشفى الجامعة متعدد التخصصات واسع أنشئت في عام 1895 باعتباره الأشعة التخصصي وفيما بعد Neuroradiologist، والحصول على قدر كبير من الخبرة في التعامل مع الكبار ورعاية الطفولة الأشعة.", englishLocal, arabicLocal);
            doc1.ImageFileName = "img1.jpg";
            doc1.Position = pSP;
            doc1.Department = depCIR;
            doc1.Qualifications.Add(this.GetQualification("National Board of Neuroradiology, (Neuroradiologist) Hungary", "المجلس الوطني للالتصوير الشعاعي العصبي، (Neuroradiologist) المجر", englishLocal, arabicLocal));
            doc1.Qualifications.Add(this.GetQualification("National Board of Radiology (Radiologist) Hungary", "المجلس الوطني للالأشعة (الأشعة) المجر", englishLocal, arabicLocal));
            doc1.Qualifications.Add(this.GetQualification("Medical Degree, Hungary", "درجة الطبية، المجر", englishLocal, arabicLocal));
            doc1.Languages.Add(lanEn);
            doc1.Languages.Add(this.GetLanguage("Farsi", "الفارسية", englishLocal, arabicLocal));
            doc1.Languages.Add(this.GetLanguage("Hungari", "هنغاريا", englishLocal, arabicLocal));            
            context.Doctors.Add(doc1);
            context.SaveChanges();

            //Doc2           
            var doc2 = this.GetDoctorObject("Ahmed Ibrahim El Bery", 
                                            "After he completed his MBBch studies at Alexandria University in 1990, Dr. Ahmed joined the Radiology department in Cairo University, gaining an MSc degree in Radiology in 1998. After that, he completed his studies at The Royal College of Radiologists, London to get an FRCR degree in 2007 before joining Al Ain Hospital as a Specialist Radiologist in 2008.",
                                           "أحمد إبراهيم بيري ديزاينز Bery",
                                           "بعد صاحب MBBCH ح الانتهاء من دراسات في جامعة الإسكندرية في عام 1990، الدكتور أحمد انضم إلى قسم الأشعة في جامعة القاهرة، والحصول على درجة الماجستير في علم الأشعة في عام 1998. وبعد ذلك، ح أكمل دراسته في الكلية الملكية للأطباء الأشعة، لندن للحصول على درجة FRCR في عام 2007 قبل أن ينضم إلى مستشفى العين أو أخصائي الأشعة أخصائي في عام 2008.", englishLocal, arabicLocal);
            doc2.ImageFileName = "img2.jpg";
            doc2.Position = pSP;
            doc2.Department = depCIR;
            doc2.Qualifications.Add(this.GetQualification("MBBch, MSC in Radiology, FRCR - London", "MBBCH، MSC في الأشعة، FRCR - لندن", englishLocal, arabicLocal));            
            doc2.Languages.Add(lanEn);
            doc2.Languages.Add(lanAr);
            context.Doctors.Add(doc2);
            context.SaveChanges();


            //Doc3            
            var depMI = this.GetDepartment("Medical Institute", "المعهد الطبي", englishLocal, arabicLocal);                        
            var doc3 = this.GetDoctorObject("Mohammed Ali Abdelsamad Hussein",
                                            "Dr. Mohammed graduated from Ain Shams University, Egypt in 1986 and finished his house officer training in the university hospital before joining PHC for 18 months. From 1990 – 1994 he had a residency in the National Heart Institute in Cairo where he became an assistant specialist and later, a specialist there until 2002. He then worked as an Echo Specialist in Hamad Medical Corporation, Qatar until 2004 and as a specialist cardiologist in Khamis Mushait Armed hospital, Abha, KSA until 2006. He has been working at Al Ain Hospital as a Specialist Cardiologist since 2006.",
                                           "محمد حسين علي عبد الصمد",
                                           "الدكتور تخرج من جامعة عين شمس محمد، مصر في عام 1986 وأنهى تدريبه ضابط منزل في مستشفى جامعة وقبل انضمامه إلى الرعاية الصحية الأولية لمدة 18 شهرا. من 1990 - 1994 ه كان لها الإقامة في المعهد القومي للقلب في القاهرة أين BECAM ح اختصاصي مساعد في وقت لاحق، قال أخصائي هناك العطور حتى عام 2002. وعمل ولا متخصص صدى في مؤسسة حمد الطبية والعطور قطر حتى عام 2004 وحتى طبيب القلب المتخصص المستشفى العسكري في خميس مشيط، أبها، العطور SAP حتى عام 2006. وقد تم العمل في مستشفى العين أو أمراض القلب التخصصي منذ عام 2006.", englishLocal, arabicLocal);           
            doc3.ImageFileName = "img3.jpg";
            doc3.Position = this.GetPosision("Specialist Cardiologist", "أمراض القلب التخصصي", englishLocal, arabicLocal);
            doc3.Department = depMI;
            doc3.SubDepartment = this.GetSubDepartment("Cardiology", "طب القلب", englishLocal, arabicLocal);
            doc3.Qualifications.Add(this.GetQualification("MBBch, Master Degree in Cardiology and PhD in Cardiology, Ain Shams University, Cairo, Egypt.", "MBBCH، درجة الماجستير في طب القلب ودرجة الدكتوراه في أمراض القلب، جامعة عين شمس، القاهرة، مصر.", englishLocal, arabicLocal));
            doc3.Qualifications.Add(this.GetQualification("Fellowship in Interventional Cardiology at National Cardiovascular Center, Osaka, Japan.", "في زمالة طب القلب التداخلي في المركز الوطني القلب والأوعية الدموية، أوساكا، اليابان.", englishLocal, arabicLocal));
            doc3.Languages.Add(lanEn);
            doc3.Languages.Add(lanAr);
            context.Doctors.Add(doc3);
            context.SaveChanges();

            //Doc4            
            var doc4 = this.GetDoctorObject("Ghassan Atta",
                                           "Dr. Ghassan joined Al Ain Hospital during 2009, after three years as a specialist neurologist at NMC Speciality Hospitals in Dubai, Abu Dhabi and Al Ain. He came to the UAE in 2006 from England following additional training courses during 2005-2006. Before this, he was working as a specialist neurologist and university teacher in Iraq at Al Kindy Teaching Hospital/Medical College - Baghdad University.",
                                          "غسان عطا",
                                          "الدكتور مستشفى غسان العين الإلتحاق تصل خلال عام 2009 بعد ثلاث سنوات ولا طبيب أعصاب متخصص في NMC المستشفيات المميزة في دبي وأبو ظبي و آل عين. انه شام لدولة الإمارات العربية المتحدة في عام 2006 من إنجلترا التالية دورات تدريبية إضافية تصل خلال 2005-2006. قبل ذلك، كان يعمل ولا طبيب أعصاب متخصص ومدرس جامعي في العراق الكندي التعليمي مستشفى كلية / الطبية - جامعة بغداد.", englishLocal, arabicLocal);                
            doc4.ImageFileName = "img4.jpg";
            doc4.Position = this.GetPosision("Specialist Neurologist", "طبيب أعصاب متخصص", englishLocal, arabicLocal); 
            doc4.Department = depMI;
            doc4.SubDepartment = this.GetSubDepartment("Neurology", "علم الأعصاب", englishLocal, arabicLocal);
            doc4.Qualifications.Add(this.GetQualification("FICMS (neurology board) - 2002.", "FICMS (علم الأعصاب مجلس) - 2002.", englishLocal, arabicLocal));
            doc4.Qualifications.Add(this.GetQualification("MBChB (Iraqi Medical College) - 1994.", "MBChB (كلية الطب العراقية) - عام 1994.", englishLocal, arabicLocal));            
            doc4.Languages.Add(lanEn);
            doc4.Languages.Add(lanAr);
            context.Doctors.Add(doc4);
            context.SaveChanges();

            //Doc5
            var doc5 = this.GetDoctorObject("John Behrendt",
                                           "After working in different hospitals in Germany for more than 22 years, Dr. John was ready for a new challenge. He joined Al Ain Hospital in September 2009 to work in the Department for Gastroenterology and Hepatology.	",
                                          "جون بهرندت",
                                          "بعد أن عمل في مستشفيات مختلفة في ألمانيا لأكثر من 22 عاما، والدكتور جون مستعدة لتحد جديد. والتحق مستشفى العين في أغسطس 2009 للعمل في إدارة أمراض الجهاز الهضمي والكبد.", englishLocal, arabicLocal);                
            doc5.ImageFileName = "img5.jpg";
            doc5.Position = this.GetPosision("Consultant Gastroenterologist", "استشاري أمراض الجهاز الهضمي", englishLocal, arabicLocal);
            doc5.Department = depMI;
            doc5.SubDepartment = this.GetSubDepartment("Gastroenterology & Hepatology", "أمراض الجهاز الهضمي والكبد", englishLocal, arabicLocal);
            doc5.Qualifications.Add(this.GetQualification("Graduate Doctor from Medical College at Free University, Berlin, Germany.", "طبيب تخرج من كلية الطب في الجامعة الحرة في برلين، ألمانيا.", englishLocal, arabicLocal));
            doc5.Qualifications.Add(this.GetQualification("Board of Internal Medicine, Nordrhein, Westfalia, Germany. ", "مجلس الطب الباطني، نوردراين، فيستفاليا بألمانيا.", englishLocal, arabicLocal));
            doc5.Qualifications.Add(this.GetQualification("Board of Vascular Medicine in Internal Medicine, Berlin, Germany. ", "مجلس الطب الأوعية الدموية في الطب الباطني، برلين، ألمانيا.", englishLocal, arabicLocal));
            
            doc5.Languages.Add(lanEn);
            doc5.Languages.Add(this.GetLanguage("German", "ألماني", englishLocal, arabicLocal));
            doc5.Languages.Add(this.GetLanguage("French", "اللغة الفرنسية", englishLocal, arabicLocal));
            context.Doctors.Add(doc5);
            context.SaveChanges();

            //###########################################################################################
            #endregion

            #region ADDING FAQS
            //###################ADDING FAQS#######################################
            var enFaq = new FaqLocalization();
            enFaq.Localization = englishLocal;
            enFaq.Question = "Q1";
            enFaq.Answer = "Answer 1";
            FaqLocalization arFaq = new FaqLocalization();
            arFaq.Localization = arabicLocal;
            arFaq.Question = "السؤال 1";
            arFaq.Answer = "الجواب 1";
            var f = new Faq();
            f.Localizations.Add(enFaq);
            f.Localizations.Add(arFaq);
            context.Faqs.Add(f);

            enFaq = new FaqLocalization();
            enFaq.Localization = englishLocal;
            enFaq.Question = "Q2";
            enFaq.Answer = "Answer 2";
            arFaq = new FaqLocalization();
            arFaq.Localization = arabicLocal;
            arFaq.Question = "الجواب 2";
            arFaq.Answer = "السؤال 2";
            f = new Faq();
            f.Localizations.Add(enFaq);
            f.Localizations.Add(arFaq);
            context.Faqs.Add(f);

            enFaq = new FaqLocalization();
            enFaq.Localization = englishLocal;
            enFaq.Question = "Q3";
            enFaq.Answer = "Answer 3";
            arFaq = new FaqLocalization();
            arFaq.Localization = arabicLocal;
            arFaq.Question = "السؤال 3";
            arFaq.Answer = "الجواب 3";
            f = new Faq();
            f.Localizations.Add(enFaq);
            f.Localizations.Add(arFaq);
            context.Faqs.Add(f);                          

            context.SaveChanges();
            //#####################################################################
            #endregion

            #region ADDING Insurance
            //###################ADDING Insurence#######################################

            var enIn = new InsuranceLocalization();
            enIn.Localization = englishLocal;
            enIn.Title = "ADNIC";
            enIn.Description = "Only Platinum";
            var arIn = new InsuranceLocalization();
            arIn.Localization = arabicLocal;
            arIn.Title = "ADNIC";
            arIn.Description = "الوحيد البلاتين";
            var ins = new Insurance();
            ins.Localizations.Add(enIn);
            ins.Localizations.Add(arIn);
            context.Insurances.Add(ins);

            enIn = new InsuranceLocalization();
            enIn.Localization = englishLocal;
            enIn.Title = "Al Hilal takaful";
            enIn.Description = "GN + SEHA & CN + SEHA";
            arIn = new InsuranceLocalization();
            arIn.Localization = arabicLocal;
            arIn.Title = "الهلال للتكافل";
            arIn.Description = "صحة و GN + CN + صحة";
            ins = new Insurance();
            ins.Localizations.Add(enIn);
            ins.Localizations.Add(arIn);
            context.Insurances.Add(ins);

            enIn = new InsuranceLocalization();
            enIn.Localization = englishLocal;
            enIn.Title = "SAICO";
            enIn.Description = "Open Network";
            arIn = new InsuranceLocalization();
            arIn.Localization = arabicLocal;
            arIn.Title = "سايكو";
            arIn.Description = "فتح شبكة";
            ins = new Insurance();
            ins.Localizations.Add(enIn);
            ins.Localizations.Add(arIn);
            context.Insurances.Add(ins);            
           
            context.SaveChanges();
            //#####################################################################
            #endregion

            #region ADDING News
            //###################ADDING Insurence#######################################

            var enNew = new NewsLocalization();
            enNew.Localization = englishLocal;
            enNew.Title = "Al Ain Hospital launches UAE’s first specialised Children’s Rheumatology Clinic";
            enNew.Description = @"Al Ain Hospital, owned and operated by Abu Dhabi Health Services Company PJSC (SEHA), has launched the nation’s first Paediatric Rheumatology Clinic.
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
            var arNew = new NewsLocalization();
            arNew.Localization = arabicLocal;
            arNew.Title = "مستشفى العين تطلق أول عيادة أمراض الروماتيزم دولة الإمارات العربية المتحدة المتخصصة للأطفال";
            arNew.Description = @"مستشفى العين، الذي تملكه وتديره شركة أبوظبي للخدمات الصحية شركة مساهمة عامة (صحة)، أطلقت أول طب الأطفال عيادة أمراض الروماتيزم في البلاد.
                                 كان لدينا إطلاق لينة في أكتوبر الداخلي لعام 2013، ولكن الآن نحن موجهة بشكل كامل للتعامل مع كميات كبيرة من المرضى الأطفال المتوقع من جميع انحاء البلاد ونحن المستشفى الوحيد في دولة الإمارات العربية المتحدة المتخصصة التي لديها قسم الروماتيزم للأطفال، وأكد د. Elsadeg محمد شريف، طبيب أطفال استشاري في طب الأطفال الروماتيزم عيادة مستشفى في مدينة العين.
                                 عيادة هو مرفق وقفة واحدة تقدم طائفة كاملة من طرائق العلاج - من التشخيص والعلاج المتطورة بما في ذلك استخدام البيولوجية التي هي المخدرات القائم على البروتين المشتقة من الكائنات المستزرعة في المختبر الحية.
                                 المرضى الذين لديهم أيضا متحالفة الحصول على الخدمات بما في ذلك الأشعة ممتازة، طب عيون الأطفال والرعاية التخدير.
وكانت قبل إطلاق هذا عيادة الأطفال الذين يعانون من مشاكل الروماتيزمية تحت رعاية أمراض الروماتيزم الكبار، ولكن الآن لدينا ميزة المرضى من كونها

                                 ثقافة تعامل من قبل الأطباء الذين لديهم تخصص مزدوج في طب الأطفال والروماتيزم، وأضاف د. شريف.
                                 و، والمعروف أيضا مرض الأكثر شيوعا وهذا يأتي ضمن اختصاص الروماتيزم والتهاب المفاصل مجهول السبب عند الأطفال الأحداث كما التهاب المفاصل الروماتويدي الأحداث، والذي يسبب للتضخم في المفاصل. هذا الشكل الأكثر انتشارا من التهاب المفاصل عند الأطفال والمراهقين.
                                 الشكاوى الشائعة الأخرى هي العائلي حمى البحر الأبيض المتوسط الذي هو التهاب وراثي مرض الذئبة الحمامية الجهازية، والمعروف باسم SLE أو الذئبة، وهو مرض يمكن أن: تؤثر على أي جزء من الجسم. كما هو الحال في أمراض المناعة الذاتية الأخرى، والجهاز المناعي يهاجم خلايا الجسم والأنسجة، مما أدى إلى التهاب الأنسجة والضرر.
                                 هذه المقاتلة ذلك استخدام بعض الأمراض في آخر، للدولة من بين الفن والعلاج في عيادتنا طرائق، داخل المفصل بما في ذلك حقن الكورتيكوستيرويد، تحت الجلد حقن الميثوتريكسيت وحقن المخدرات بيولوجي، وأوضح طريق. شريف.
                                 يتم حقن الكورتيزون داخل المفصل أو المنشطات الأدوية في المفصل الفضاء مباشرة من المؤلم، المفصل الملتهب ملتهبة. المنشطات هي مماثلة أيهما مواد طبيعية ينتجها الجسم (الهرمونات) تساعد على تقليل الالتهاب.
                                 ويشمل حقن تحت الجلد الميثوتريكسيت حقن المخدرات في الطبقة الدهنية من الأنسجة تحت الجلد. تستخدم البيولوجية حقن المخدرات البيولوجية، والتي تشمل المنتجات الطبية الجافة لقاحات، والدم أو مكونات الدم والأنسجة والخلايا الحية، الخ التي أنشأتها العمليات البيولوجية وSynthesised وليس كيميائيا، والتي يتم استخدامها في علاجات لعلاج الأمراض.

                                 مع إطلاق في نتوقع أن توفير الرعاية الممتازة الخاص بك هو حوالي 10 - 12 مريضا يوميا في عيادة الذي يقع في مجمع مستشفى العين، وأوضح الدكتور شريف.
                                 بين خططنا للتنمية المستقبلية هي العلاج الطبيعي والمهني من خدمات العلاج وإنشاء العيادات الخارجية، أوجز الدكتور شريف.";
            var n = new News();
            n.Localizations.Add(enNew);
            n.Localizations.Add(arNew);
            n.Date = new DateTime(2014, 3, 9);
            context.News.Add(n);


            enNew = new NewsLocalization();
            enNew.Localization = englishLocal;
            enNew.Title = "Al Ain Hospital Expands Internal Medicine Facilities";
            enNew.Description = @"Al Ain Hospital, owned and operated by Abu Dhabi Health Services Company PJSC (SEHA) and managed by Medical University of Vienna and VAMED, today announced renewing and expanding its internal medicine consultancy practice to serve the rising number of patients to its specialist clinics.
                                        In a statement, the hospital said that in its continuing endeavor to serve the Al Ain community better with enhanced standards of medical facilities, it has added 122 more beds to its internal medicine facilities and increased the number of consultancy clinics to 20, adding four new units. 
                                        The four new clinics under the Internal Medical Institute include consultancies in diabetics, ENT, foot care and eye care. Apart from these clinics, the Internal Medical Institute is also offering advisory on healthy eating habits and behavioral changes for diabetic patients.
                                        The hospital said the clinics under the ambit of the Internal Medical Institute receive some 67,000 patients a year and enhancing the facilities and standards will help the healthcare body serve the community better.
                                        Mr. George Jepson, CEO of Al Ain Hospital said:”.Our aim and mandate is to provide complete medical consultancy services and expert treatment facilities to the UAE nationals and expats. We have best-in-class internal medicine clinics with cutting-edge expertise across various disciplines to serve the community better.”
                                        Dr. Talaat Diab, Consultant, Internal Medicine and Deputy Director of Al Ain Hospital’s Internal Medical Institute said that the new developments including new disciplines and services at higher standards were a great achievement which will add value to the hospital’s positioning as a community-focused healthcare institute.
                                        “We are proud of these new developments and these enhancements at the Internal Medical Institute have come in the context of rising number of patients to the clinics. In the last five months alone, we received some 32,000 patients in our internal medicine clinics,” he said.";
            arNew = new NewsLocalization();
            arNew.Localization = arabicLocal;
            arNew.Title = "مستشفى العين لطب الباطني توسع المرافق";
            arNew.Description = @"مستشفى العين، الذي تملكه وتديره شركة أبوظبي للخدمات الصحية شركة مساهمة عامة (صحة) وتديره جامعة فيينا الطبية وفاميد، اليوم أعلن تجديد وتوسيع الاستشارات في ممارسة الطب الداخلية لخدمة العدد المتزايد من المرضى أن العيادات المتخصصة فيها.
                                         وفي بيان، قال المستشفى في استمرارها في هذا المسعى لخدمة المجتمع العين بشكل أفضل مع معايير محسنة من المرافق الطبية، فإنه قد أضاف 122 مزيد من الأسرة هو منشآتها الطب الداخلي وزيادة عدد العيادات الاستشارية إلى 20، وأضاف أربعة جديد وحدة.
                                         وتشمل العيادات الأربعة الجديدة تحت المعهد الطبي الداخلية الاستشارات في مرضى السكري، الأنف والحنجرة، العناية بالقدم والعناية بالعين. وبصرف النظر عن هذه العيادات، المعهد الطبي الداخلية تقدم أيضا الاستشارية لعادات الأكل الصحية والتغيرات السلوكية لمرضى السكري. &
                                         وقال المستشفى في العيادات تحت نطاق من الداخلية الطبية معهد المرضى يتلقون بعض 67،000 سنة، وسوف تحسين المرافق ومعايير تساعد الجسم الرعاية الصحية تقديم خدمة أفضل للمجتمع.
                                         السيد. وقال جورج جيبسون، الرئيس التنفيذي لمستشفى العين: هدفنا وولاية هو تقديم خدمات الاستشارات الطبية الكاملة الخاصة بك ومرافق معالجة الخبراء للمواطنين والمغتربين الإمارات العربية المتحدة. لدينا أفضل سيارة في فئتها عيادات الطب الداخلي مع الخبرات المتطورة في مختلف التخصصات لخدمة المجتمع بشكل أفضل.
                                         الدكتور وقال طلعت دياب، مستشار، الطب الباطني ونائب مدير معهد مستشفى العين الداخلية الطبية التي كانت التطورات الجديدة بما في ذلك التخصصات والخدمات في معايير أعلى الجديدة إنجازا كبيرا والتي سوف تضيف قيمة إلى المواقع المستشفى كمعهد الرعاية الصحية التي تركز على المجتمع.
                                         نحن فخورون هذه التطورات الجديدة وهذه التحسينات في المعهد الطبي الداخلية قد تأتي في سياق ارتفاع عدد المرضى إلى العيادات. وقال في الأشهر الخمسة الماضية وحدها، وتلقى بعض 32،000 المرضى في عيادات الطب الداخلي لدينا.";
            n = new News();
            n.Localizations.Add(enNew);
            n.Localizations.Add(arNew);
            n.Date = new DateTime(2012, 6, 28);
            context.News.Add(n);


            enNew = new NewsLocalization();
            enNew.Localization = englishLocal;
            enNew.Title = "Opening Professorial Medical Unit";
            enNew.Description = @"Goal
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
            arNew = new NewsLocalization();
            arNew.Localization = arabicLocal;
            arNew.Title = "الوحدة الطبية استاذي افتتاح";
            arNew.Description = @"هدف
                                  الهدف الأساسي من وحدة إدارة المشروع هو توفير الخاصة بك نموذجا يحتذى به للرعاية الطبية في بيئة أكاديمية، مع عناصر من الخبرة في خدمة السريرية والتعليم والتدريس من الأطباء والمتدربين والطلاب المقيمين. ويستند هذا على فلسفة وهذا هو أفضل تسليمها حققت التميز في رعاية المرضى عندما تكون في جو من الاستفسار والنقاش والتدريس.

                                  آليات تقديم خدمات الرعاية

                                  وحدة إدارة المشروع وتتعاون مع غيرها من الوحدات الطبية في المعهد الطبي في الحادة عند الطلب والمريض في رعاية المرضى بأمراض خطيرة، والعمل تحت قيادة السريرية للطبيب استشاري معتمد من قبل مجلس الطب الباطني FMHS. ويدعم هذا المستشار من قبل أخصائي آآآه ذوي الخبرة في الطب الباطني مع موعد مساعد في FMHS الأكاديمي والمقيم من برنامج العين الطبية منطقة الإقامة التدريب (العربية مجلس المعتمدة)، وكذلك متدربة وطلاب الطب.
                                  يأخذ موظفي وحدة إدارة المشروع جزء في التقرير صباح اليوم على مستوى القسم ويساهم في CME المستشفى والأنشطة التعليمية الأخرى. جولات التدريس برئاسة المستشار هي FMHS وأجرت يوميا على المرضى PMU. &
                                  وحدة إدارة المشروع مخصص للمرضى الخارجيين عيادة ويوفر استمرارية الرعاية للمرضى تفريغها من المريض في منشأة PMU. وبالإضافة إلى ذلك على بنداء القبول، ومستشار FMHS الداخلية أطباء مباشرة أيضا يعترفون المرضى أن وحدة إدارة المشروع للعمل حتى والتشخيص والإدارة.
                                  جميع FMHS الداخلية استشاري أطباء المرضى أعترف مباشرة أن وحدة إدارة المشروع بالإضافة على بنداء القبول، للعمل حتى والتشخيص والإدارة.

                                  تدريس
                                  في هذه الرعاية السريرية بالإضافة إلى ذلك، تدريس تشمل أنشطة PMU الأسبوعية قضية الأسبوع، ومناقشة المقالات الصحفية، وعقد مؤتمر السريرية الإشعاعية. وحدة إدارة المشروع لديه غرفة مخصصة التدريس مع مرافق AV وخدمة الإنترنت. ويعقد التقرير الصباحي بقيادة كلية لطلاب الطب يوميا وأيضا حضور المقيمين مخصص الأكاديمي لمدة نصف يوم في FMHS تحت إشراف المديرين مبرمج.

                                  بحث
                                  وحدة إدارة المشروع لديه مكتب ابحاث مخصص لإجراء التجارب السريرية وغيرها من البحوث، وكلاهما مستمرة بنشاط.
                                  Aduit التقييم، والمبادئ التوجيهية
                                  وتجري عمليات التدقيق عليها التأكد رضا المرضى وجودة الرعاية في مختلف المناطق الجافة كما وصف الأدوية المضادة للميكروبات، ومسارات السريرية لحالات الطوارئ الطبية المختارة كما يجري إعدادها.";
            n = new News();
            n.Localizations.Add(enNew);
            n.Localizations.Add(arNew);
            n.Date = new DateTime(2008, 4, 1);
            context.News.Add(n);

            context.SaveChanges();
            //#####################################################################
            #endregion

            #region ADDING CME
            var enCme = new CmeLocalization();
            enCme.Localization = englishLocal;
            enCme.Title = "";
            enCme.Description = "dsfgdfsg fhfsgsdff sadfdsa fgfsh fg hsd safsd fsda fsda fd gdf";
            enCme.Speaker = "sdfasdf";
            enCme.Venue = "sadfsda gdfs gdfgfdsg ds";
            enCme.CreditHours = "1h";
            var arCme = new CmeLocalization();
            arCme.Localization = arabicLocal;
            arCme.Title = "";
            arCme.Description = "ARABIC description";
            arCme.Speaker = "ARABIC text";
            arCme.Venue = "ARABIC text2";
            arCme.CreditHours = "h";
            var cme = new Cme();
            cme.Date = DateTime.Now.AddDays(1);
            cme.Localizations.Add(enCme);
            cme.Localizations.Add(arCme);
            context.Cmes.Add(cme);

            enCme = new CmeLocalization();
            enCme.Localization = englishLocal;
            enCme.Title = "";
            enCme.Description = "dsfgdfsg fhfsgsdff sadfdsa fgfsh fg hsd safsd fsda fsda fd gdf";
            enCme.Speaker = "sdfasdf";
            enCme.Venue = "sadfsda gdfs gdfgfdsg ds";
            enCme.CreditHours = "1h";
            arCme = new CmeLocalization();
            arCme.Localization = arabicLocal;
            arCme.Title = "";
            arCme.Description = "ARABIC description";
            arCme.Speaker = "ARABIC text";
            arCme.Venue = "ARABIC text2";
            arCme.CreditHours = "h";
            cme = new Cme();
            cme.Date = DateTime.Now.AddDays(1);
            cme.Localizations.Add(enCme);
            cme.Localizations.Add(arCme);
            context.Cmes.Add(cme);            

            context.SaveChanges();
            //#####################################################################
            #endregion

            #region ADDING Events
            var enEvent = new EventLocalization();
            enEvent.Localization = englishLocal;
            enEvent.Title = "Event1";
            enEvent.Description = "adsg fd gdf gdsfg sdf gsdf gsdfg dsf";
            enEvent.Venue = "hndfsd gdsf gdsf gfds gfds gsdf gds";
            var arEvent = new EventLocalization();
            arEvent.Localization = arabicLocal;
            arEvent.Title = "الحدث 1";
            arEvent.Description = "adsg fd gdf gdsfg sdf gsdf gsdfg dsf";
            arEvent.Venue = "hndfsd gdsf gdsf gfds gfds gsdf gds";
            var ev = new Event();
            ev.Date = DateTime.Now;
            ev.Localizations.Add(enEvent);
            ev.Localizations.Add(arEvent);
            context.Events.Add(ev);

            enEvent = new EventLocalization();
            enEvent.Localization = englishLocal;
            enEvent.Title = "Event2";
            enEvent.Description = "adsg fd gdf gdsfg sdf gsdf gsdfg dsf";
            enEvent.Venue = "hndfsd gdsf gdsf gfds gfds gsdf gds";
            arEvent = new EventLocalization();
            arEvent.Localization = arabicLocal;
            arEvent.Title = "الحدث 2";
            arEvent.Description = "adsg fd gdf gdsfg sdf gsdf gsdfg dsf";
            arEvent.Venue = "hndfsd gdsf gdsf gfds gfds gsdf gds";
            ev = new Event();
            ev.Date = DateTime.Now;
            ev.Localizations.Add(enEvent);
            ev.Localizations.Add(arEvent);
            context.Events.Add(ev);

            enEvent = new EventLocalization();
            enEvent.Localization = englishLocal;
            enEvent.Title = "Event3";
            enEvent.Description = "adsg fd gdf gdsfg sdf gsdf gsdfg dsf";
            enEvent.Venue = "hndfsd gdsf gdsf gfds gfds gsdf gds";
            arEvent = new EventLocalization();
            arEvent.Localization = arabicLocal;
            arEvent.Title = "الحدث 3";
            arEvent.Description = "adsg fd gdf gdsfg sdf gsdf gsdfg dsf";
            arEvent.Venue = "hndfsd gdsf gdsf gfds gfds gsdf gds";
            ev = new Event();
            ev.Date = DateTime.Now;
            ev.Localizations.Add(enEvent);
            ev.Localizations.Add(arEvent);
            context.Events.Add(ev);

            enEvent = new EventLocalization();
            enEvent.Localization = englishLocal;
            enEvent.Title = "Event4";
            enEvent.Description = "adsg fd gdf gdsfg sdf gsdf gsdfg dsf";
            enEvent.Venue = "hndfsd gdsf gdsf gfds gfds gsdf gds";
            arEvent = new EventLocalization();
            arEvent.Localization = arabicLocal;
            arEvent.Title = "الحدث 4";
            arEvent.Description = "adsg fd gdf gdsfg sdf gsdf gsdfg dsf";
            arEvent.Venue = "hndfsd gdsf gdsf gfds gfds gsdf gds";
            ev = new Event();
            ev.Date = DateTime.Now;
            ev.Localizations.Add(enEvent);
            ev.Localizations.Add(arEvent);
            context.Events.Add(ev);

            context.SaveChanges();
            #endregion
        }

        private Doctor GetDoctorObject(string enName, string enBio, string arName, string arBio, LocalizationLanguage englishLocal, LocalizationLanguage arabicLocal)
        {
            var enDoctor = new DoctorLocalization();
            enDoctor.Localization = englishLocal;
            enDoctor.Name = enName;
            enDoctor.Bio = enBio;
            var arDoctor = new DoctorLocalization();
            arDoctor.Localization = arabicLocal;
            arDoctor.Name = arName;
            arDoctor.Bio = arBio;
            var doc = new Doctor();
            doc.Localizations.Add(enDoctor);
            doc.Localizations.Add(arDoctor);

            return doc;
        }

        private Qualification GetQualification(string enName, string arName, LocalizationLanguage englishLocal, LocalizationLanguage arabicLocal)
        {
            var enQ = new QualificationLocalization();
            enQ.Localization = englishLocal;
            enQ.Name = enName;
            var arQ = new QualificationLocalization();
            arQ.Localization = arabicLocal;
            arQ.Name = arName;
            var q = new Qualification();
            q.Localizations.Add(enQ);
            q.Localizations.Add(arQ);
            return q;
        }

        private Position GetPosision(string enName, string arName, LocalizationLanguage englishLocal, LocalizationLanguage arabicLocal)
        {
            var enPos = new PositionLocalization();
            enPos.Localization = englishLocal;
            enPos.Name = enName;
            var arPos = new PositionLocalization();
            arPos.Localization = arabicLocal;
            arPos.Name = arName;
            var pSP = new Position();
            pSP.Localizations.Add(enPos);
            pSP.Localizations.Add(arPos);

            return pSP;
        }

        private Language GetLanguage(string enName, string arName, LocalizationLanguage englishLocal, LocalizationLanguage arabicLocal)
        {
            var enLoc = new LanguageLocalization();
            enLoc.Localization = englishLocal;
            enLoc.Name = enName;
            var aLoc = new LanguageLocalization();
            aLoc.Localization = arabicLocal;
            aLoc.Name = arName;
            var lan = new Language();
            lan.Localizations.Add(enLoc);
            lan.Localizations.Add(aLoc);

            return lan;
        }

        private Department GetDepartment(string enName, string arName, LocalizationLanguage englishLocal, LocalizationLanguage arabicLocal)
        {
            var enLoc = new DepartmentLocalization();
            enLoc.Localization = englishLocal;
            enLoc.Name = enName;
            var aLoc = new DepartmentLocalization();
            aLoc.Localization = arabicLocal;
            aLoc.Name = arName;
            var dep = new Department();
            dep.Localizations.Add(enLoc);
            dep.Localizations.Add(aLoc);

            return dep;
        }

        private SubDepartment GetSubDepartment(string enName, string arName, LocalizationLanguage englishLocal, LocalizationLanguage arabicLocal)
        {
            var enLoc = new SubDepartmentLocalization();
            enLoc.Localization = englishLocal;
            enLoc.Name = enName;
            var aLoc = new SubDepartmentLocalization();
            aLoc.Localization = arabicLocal;
            aLoc.Name = arName;
            var dep = new SubDepartment();
            dep.Localizations.Add(enLoc);
            dep.Localizations.Add(aLoc);

            return dep;
        }
    }
}
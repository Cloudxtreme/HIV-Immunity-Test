using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIV_Immunity_Test
{
    public partial class HIVImmunityFrm : Form
    {
        Dictionary<string, string> hivimmune_pos = null;

        List<string> hivimmune_match = null;

        const int RESULT_PROB_TRUE = 2;
        const int RESULT_TRUE = 1;
        const int RESULT_FALSE = 0;
        const int RESULT_NA = -1;

        public HIVImmunityFrm()
        {
            InitializeComponent();
        }

        private void HIVImmunityFrm_Load(object sender, EventArgs e)
        {
            hivimmune_match = new List<string>();
            hivimmune_pos = new Dictionary<string, string>();
            hivimmune_pos.Add("rs3774675", "C");
            hivimmune_pos.Add("rs4683131", "G");
            hivimmune_pos.Add("rs17078140", "G");
            hivimmune_pos.Add("rs893562", "C");
            hivimmune_pos.Add("rs2012755", "T");
            hivimmune_pos.Add("rs2012762", "T");
            hivimmune_pos.Add("rs9865354", "A");
            hivimmune_pos.Add("rs3796362", "C");
            hivimmune_pos.Add("rs3774667", "A");
            hivimmune_pos.Add("rs7648681", "A");
            hivimmune_pos.Add("rs2235130", "A");
            hivimmune_pos.Add("rs7648441", "A");
            hivimmune_pos.Add("rs9846194", "T");
            hivimmune_pos.Add("rs2742408", "A");
            hivimmune_pos.Add("rs12493946", "C");
            hivimmune_pos.Add("rs2742407", "C");
            hivimmune_pos.Add("rs17078175", "G");
            hivimmune_pos.Add("rs1318992", "T");
            hivimmune_pos.Add("rs1962892", "C");
            hivimmune_pos.Add("rs2742409", "G");
            hivimmune_pos.Add("rs2247771", "T");
            hivimmune_pos.Add("rs3796361", "G");
            hivimmune_pos.Add("rs6441927", "G");
            hivimmune_pos.Add("rs11719053", "A");
            hivimmune_pos.Add("rs17262464", "T");
            hivimmune_pos.Add("rs2742412", "T");
            hivimmune_pos.Add("rs2742413", "T");
            hivimmune_pos.Add("rs2742416", "A");
            hivimmune_pos.Add("rs4682797", "A");
            hivimmune_pos.Add("rs2673051", "T");
            hivimmune_pos.Add("rs1969624", "C");
            hivimmune_pos.Add("rs2742424", "G");
            hivimmune_pos.Add("rs2673050", "T");
            hivimmune_pos.Add("rs938365", "A");
            hivimmune_pos.Add("rs6786791", "A");
            hivimmune_pos.Add("rs1877931", "G");
            hivimmune_pos.Add("rs2742369", "A");
            hivimmune_pos.Add("rs2271619", "A");
            hivimmune_pos.Add("rs2248991", "A");
            hivimmune_pos.Add("rs2673028", "G");
            hivimmune_pos.Add("rs13086080", "CT");
            hivimmune_pos.Add("rs2673062", "G");
            hivimmune_pos.Add("rs2742448", "G");
            hivimmune_pos.Add("rs13316262", "G");
            hivimmune_pos.Add("rs1468542", "T");
            hivimmune_pos.Add("rs1019129", "C");
            hivimmune_pos.Add("rs12490575", "C");
            hivimmune_pos.Add("rs12495593", "A");
            hivimmune_pos.Add("rs2251109", "T");
            hivimmune_pos.Add("rs2742388", "G");
            hivimmune_pos.Add("rs17078308", "T");
            hivimmune_pos.Add("rs17213127", "C");
            hivimmune_pos.Add("rs2251347", "T");
            hivimmune_pos.Add("rs2191028", "C");
            hivimmune_pos.Add("rs2286489", "C");
            hivimmune_pos.Add("rs2191027", "C");
            hivimmune_pos.Add("rs6770261", "T");
            hivimmune_pos.Add("rs10461016", "T");
            hivimmune_pos.Add("rs9873753", "C");
            hivimmune_pos.Add("rs4299518", "CT");
            hivimmune_pos.Add("rs4327428", "CA");
            hivimmune_pos.Add("rs2108917", "A");
            hivimmune_pos.Add("rs720625", "A");
            hivimmune_pos.Add("rs720626", "T");
            hivimmune_pos.Add("rs9818982", "GA");
            hivimmune_pos.Add("rs758387", "G");
            hivimmune_pos.Add("rs17279437", "GA");
            hivimmune_pos.Add("rs17279465", "G");
            hivimmune_pos.Add("rs13062383", "C");
            hivimmune_pos.Add("rs758386", "G");
            hivimmune_pos.Add("rs2531748", "G");
            hivimmune_pos.Add("rs13067466", "T");
            hivimmune_pos.Add("rs2742399", "G");
            hivimmune_pos.Add("rs2276857", "C");
            hivimmune_pos.Add("rs17078339", "A");
            hivimmune_pos.Add("rs2531747", "T");
            hivimmune_pos.Add("rs9848415", "G");
            hivimmune_pos.Add("rs2159272", "A");
            hivimmune_pos.Add("rs7644870", "A");
            hivimmune_pos.Add("rs12488144", "A");
            hivimmune_pos.Add("rs1860263", "A");
            hivimmune_pos.Add("rs13064991", "G");
            hivimmune_pos.Add("rs2271615", "G");
            hivimmune_pos.Add("rs2531742", "A");
            hivimmune_pos.Add("rs17078346", "A");
            hivimmune_pos.Add("rs9843503", "T");
            hivimmune_pos.Add("rs2531757", "A");
            hivimmune_pos.Add("rs11130076", "T");
            hivimmune_pos.Add("rs4683143", "C");
            hivimmune_pos.Add("rs2531756", "C");
            hivimmune_pos.Add("rs13318088", "A");
            hivimmune_pos.Add("rs9814578", "G");
            hivimmune_pos.Add("rs4683145", "A");
            hivimmune_pos.Add("rs10490770", "T");
            hivimmune_pos.Add("rs1058961", "C");
            hivimmune_pos.Add("rs1129183", "C");
            hivimmune_pos.Add("rs2064061", "G");
            hivimmune_pos.Add("rs11130077", "A");
            hivimmune_pos.Add("rs1488369", "T");
            hivimmune_pos.Add("rs1883092", "T");
            hivimmune_pos.Add("rs17078371", "A");
            hivimmune_pos.Add("rs7614952", "G");
            hivimmune_pos.Add("rs9856760", "A");
            hivimmune_pos.Add("rs2191032", "T");
            hivimmune_pos.Add("rs7625839", "T");
            hivimmune_pos.Add("rs2191031", "G");
            hivimmune_pos.Add("rs2191030", "C");
            hivimmune_pos.Add("rs12639224", "C");
            hivimmune_pos.Add("rs9842595", "G");
            hivimmune_pos.Add("rs1860264", "A");
            hivimmune_pos.Add("rs9868455", "T");
            hivimmune_pos.Add("rs6441929", "A");
            hivimmune_pos.Add("rs7613548", "G");
            hivimmune_pos.Add("rs7653372", "T");
            hivimmune_pos.Add("rs12638201", "G");
            hivimmune_pos.Add("rs7648467", "C");
            hivimmune_pos.Add("rs2236938", "G");
            hivimmune_pos.Add("rs17078408", "T");
            hivimmune_pos.Add("rs12721497", "A");
            hivimmune_pos.Add("rs875890", "T");
            hivimmune_pos.Add("rs4683147", "A");
            hivimmune_pos.Add("rs12493471", "C");
            hivimmune_pos.Add("rs4683148", "T");
            hivimmune_pos.Add("rs1488373", "T");
            hivimmune_pos.Add("rs7129", "C");
            hivimmune_pos.Add("rs1047444", "A");
            hivimmune_pos.Add("rs1994491", "G");
            hivimmune_pos.Add("rs3796373", "C");
            hivimmune_pos.Add("rs1488374", "T");
            hivimmune_pos.Add("rs7652331", "C");
            hivimmune_pos.Add("rs6441934", "C");
            hivimmune_pos.Add("rs6800954", "C");
            hivimmune_pos.Add("rs9860832", "C");
            hivimmune_pos.Add("rs1123434", "C");
            hivimmune_pos.Add("rs4683152", "T");
            hivimmune_pos.Add("rs1072755", "G");
            hivimmune_pos.Add("rs4535265", "T");
            hivimmune_pos.Add("rs11130079", "G");
            hivimmune_pos.Add("rs17078449", "G");
            hivimmune_pos.Add("rs936938", "T");
            hivimmune_pos.Add("rs3774640", "G");
            hivimmune_pos.Add("rs7627147", "C");
            hivimmune_pos.Add("rs936939", "C");
            hivimmune_pos.Add("rs2234358", "G");
            hivimmune_pos.Add("rs2234359", "T");
            hivimmune_pos.Add("rs17078463", "T");
            hivimmune_pos.Add("rs2054866", "G");
            hivimmune_pos.Add("rs4682799", "C");
            hivimmune_pos.Add("rs1463680", "A");
            hivimmune_pos.Add("rs13069079", "G");
            hivimmune_pos.Add("rs1545985", "A");
            hivimmune_pos.Add("rs3796374", "T");
            hivimmune_pos.Add("rs13079869", "G");
            hivimmune_pos.Add("rs3796375", "A");
            hivimmune_pos.Add("rs3733101", "G");
            hivimmune_pos.Add("rs17214952", "A");
            hivimmune_pos.Add("rs751553", "T");
            hivimmune_pos.Add("rs4682801", "T");
            hivimmune_pos.Add("rs4683159", "G");
            hivimmune_pos.Add("rs737452", "A");
            hivimmune_pos.Add("rs2133660", "T");
            hivimmune_pos.Add("rs1873001", "T");
            hivimmune_pos.Add("rs3947589", "G");
            hivimmune_pos.Add("rs1392288", "C");
            hivimmune_pos.Add("rs17330872", "A");
            hivimmune_pos.Add("rs2171529", "A");
            hivimmune_pos.Add("rs6764042", "T");
            hivimmune_pos.Add("rs13074382", "A");
            hivimmune_pos.Add("rs13097556", "T");
            hivimmune_pos.Add("rs7650968", "T");
            hivimmune_pos.Add("rs2230322", "T");
            hivimmune_pos.Add("rs13060901", "G");
            hivimmune_pos.Add("rs7638309", "A");
            hivimmune_pos.Add("rs7642229", "A");
            hivimmune_pos.Add("rs2036293", "T");
            hivimmune_pos.Add("rs2173640", "G");
            hivimmune_pos.Add("rs2036295", "C");
            hivimmune_pos.Add("rs1392293", "T");
            hivimmune_pos.Add("rs1392294", "G");
            hivimmune_pos.Add("rs4490403", "C");
            hivimmune_pos.Add("rs4490404", "C");
            hivimmune_pos.Add("rs1604068", "A");
            hivimmune_pos.Add("rs1500005", "A");
            hivimmune_pos.Add("rs9311384", "C");
            hivimmune_pos.Add("rs9825081", "G");
            hivimmune_pos.Add("rs1388608", "G");
            hivimmune_pos.Add("rs13434336", "T");
            hivimmune_pos.Add("rs1491960", "G");
            hivimmune_pos.Add("rs9838450", "A");
            hivimmune_pos.Add("rs9990063", "T");
            hivimmune_pos.Add("rs9990060", "A");
            hivimmune_pos.Add("rs4683177", "C");
            hivimmune_pos.Add("rs902760", "C");
            hivimmune_pos.Add("rs751625", "A");
            hivimmune_pos.Add("rs10510747", "G");
            hivimmune_pos.Add("rs1491950", "G");
            hivimmune_pos.Add("rs13086717", "A");
            hivimmune_pos.Add("rs9872121", "A");
            hivimmune_pos.Add("rs1491951", "G");
            hivimmune_pos.Add("rs1491952", "C");
            hivimmune_pos.Add("rs6772051", "G");
            hivimmune_pos.Add("rs2888512", "T");
            hivimmune_pos.Add("rs1546077", "T");
            hivimmune_pos.Add("rs12485978", "C");
            hivimmune_pos.Add("rs2373154", "A");
            hivimmune_pos.Add("rs13320534", "G");
            hivimmune_pos.Add("rs10433607", "G");
            hivimmune_pos.Add("rs6774742", "C");
            hivimmune_pos.Add("rs4683182", "G");
            hivimmune_pos.Add("rs6789719", "A");
            hivimmune_pos.Add("rs902761", "T");
            hivimmune_pos.Add("rs10510749", "C");
            hivimmune_pos.Add("rs7631551", "C");
            hivimmune_pos.Add("rs7616215", "T");
            hivimmune_pos.Add("rs2172246", "A");
            hivimmune_pos.Add("rs13061548", "T");
            hivimmune_pos.Add("rs13098911", "C");
            hivimmune_pos.Add("rs7615337", "A");
            hivimmune_pos.Add("rs7617872", "A");
            hivimmune_pos.Add("rs3136673", "C");
            hivimmune_pos.Add("rs3136671", "C");
            hivimmune_pos.Add("rs3136670", "C");
            hivimmune_pos.Add("rs3136665", "G");
            hivimmune_pos.Add("rs3136664", "C");
            hivimmune_pos.Add("rs1491961", "C");
            hivimmune_pos.Add("rs17283264", "A");
            hivimmune_pos.Add("rs11926063", "A");
            hivimmune_pos.Add("rs11914967", "C");
            hivimmune_pos.Add("rs1979672", "A");
            hivimmune_pos.Add("rs1979671", "T");
            hivimmune_pos.Add("rs4683189", "G");
            hivimmune_pos.Add("rs13096142", "C");
            hivimmune_pos.Add("rs9853223", "A");
            hivimmune_pos.Add("rs13073976", "T");
            hivimmune_pos.Add("rs9854776", "C");
            hivimmune_pos.Add("rs6441948", "A");
            hivimmune_pos.Add("rs7652290", "A");
            hivimmune_pos.Add("rs1491962", "C");
            hivimmune_pos.Add("rs4987053", "T");
            hivimmune_pos.Add("rs3091312", "T");
            hivimmune_pos.Add("rs4413345", "T");
            hivimmune_pos.Add("rs1027241", "A");
            hivimmune_pos.Add("rs9810242", "A");
            hivimmune_pos.Add("rs4383561", "T");
            hivimmune_pos.Add("rs9839623", "G");
            hivimmune_pos.Add("rs6810232", "T");
            hivimmune_pos.Add("rs4683207", "T");
            hivimmune_pos.Add("rs4267678", "C");
            hivimmune_pos.Add("rs7645716", "G");
            hivimmune_pos.Add("rs9990343", "G");
            hivimmune_pos.Add("rs4683211", "G");
            hivimmune_pos.Add("rs11711054", "A");
            hivimmune_pos.Add("rs10510751", "T");
            hivimmune_pos.Add("rs11712150", "C");
            hivimmune_pos.Add("rs4513489", "T");
            hivimmune_pos.Add("rs6441961", "C");
            hivimmune_pos.Add("rs4683215", "A");
            hivimmune_pos.Add("rs2213288", "G");
            hivimmune_pos.Add("rs2097284", "C");
            hivimmune_pos.Add("rs1894387", "G");
            hivimmune_pos.Add("rs3918359", "T");
            hivimmune_pos.Add("rs3762823", "G");
            hivimmune_pos.Add("rs3092962", "G");
            hivimmune_pos.Add("rs1799864", "G");
            hivimmune_pos.Add("rs1799865", "T");
            hivimmune_pos.Add("rs3138042", "A");
            hivimmune_pos.Add("rs1034382", "A");
            hivimmune_pos.Add("rs3136536", "C");
            hivimmune_pos.Add("rs7637813", "A");
            hivimmune_pos.Add("rs2856758", "G");
            hivimmune_pos.Add("rs2734648", "G");
            hivimmune_pos.Add("rs1799987", "A");
            hivimmune_pos.Add("rs41469351", "C");
            hivimmune_pos.Add("rs1800023", "A");
            hivimmune_pos.Add("rs1800024", "C");
            hivimmune_pos.Add("rs2856762", "C");
            hivimmune_pos.Add("rs2254089", "C");
            hivimmune_pos.Add("rs1800874", "G");
            hivimmune_pos.Add("rs746492", "G");
            hivimmune_pos.Add("rs7652037", "C");
            hivimmune_pos.Add("rs4683220", "A");
            hivimmune_pos.Add("rs17141079", "T");
            hivimmune_pos.Add("rs4683222", "T");
            hivimmune_pos.Add("rs916092", "A");
            hivimmune_pos.Add("rs11574436", "G");
            hivimmune_pos.Add("rs11574443", "A");
            hivimmune_pos.Add("rs6808835", "T");
            hivimmune_pos.Add("rs6791599", "A");
            hivimmune_pos.Add("rs6441983", "T");
            hivimmune_pos.Add("rs6441989", "G");
            hivimmune_pos.Add("rs3213479", "A");
            hivimmune_pos.Add("rs1034384", "A");
            hivimmune_pos.Add("rs9110", "A");
            hivimmune_pos.Add("rs2073495", "C");
            hivimmune_pos.Add("rs3828477", "T");
            hivimmune_pos.Add("rs1042073", "G");
            hivimmune_pos.Add("rs2269437", "G");
            hivimmune_pos.Add("rs2269442", "A");
            hivimmune_pos.Add("rs6441995", "C");
            hivimmune_pos.Add("rs11707471", "T");
            hivimmune_pos.Add("rs17078864", "C");
            hivimmune_pos.Add("rs17078868", "G");
            hivimmune_pos.Add("rs17078876", "C");
            hivimmune_pos.Add("rs17078878", "C");
            hivimmune_pos.Add("rs1126478", "T");
            hivimmune_pos.Add("rs1126477", "C");
            hivimmune_pos.Add("rs4683235", "C");
            hivimmune_pos.Add("rs13070740", "G");
            hivimmune_pos.Add("rs9862186", "A");
            hivimmune_pos.Add("rs4683236", "G");
            hivimmune_pos.Add("rs4521278", "T");
            hivimmune_pos.Add("rs885485", "A");
            hivimmune_pos.Add("rs1520484", "C");
            hivimmune_pos.Add("rs2139634", "T");
            hivimmune_pos.Add("rs1402151", "C");
            hivimmune_pos.Add("rs7644995", "T");
            hivimmune_pos.Add("rs867620", "T");
            hivimmune_pos.Add("rs883740", "G");
            hivimmune_pos.Add("rs7430431", "C");
            hivimmune_pos.Add("rs10514713", "A");
            hivimmune_pos.Add("rs7371865", "C");
            hivimmune_pos.Add("rs2068099", "G");
            hivimmune_pos.Add("rs6808142", "T");
            hivimmune_pos.Add("rs17030627", "G");
            hivimmune_pos.Add("rs13093282", "C");
            hivimmune_pos.Add("rs6791703", "T");
            hivimmune_pos.Add("rs11713015", "C");
            hivimmune_pos.Add("rs9849400", "C");
            hivimmune_pos.Add("rs1402152", "A");
            hivimmune_pos.Add("rs939421", "C");
            hivimmune_pos.Add("rs17220622", "T");
            hivimmune_pos.Add("rs17078944", "G");
            hivimmune_pos.Add("rs7648827", "C");
            hivimmune_pos.Add("rs17286758", "T");
            hivimmune_pos.Add("rs9883208", "A");
            hivimmune_pos.Add("rs6774189", "A");
            hivimmune_pos.Add("rs1879325", "A");
            hivimmune_pos.Add("rs11919651", "A");
            hivimmune_pos.Add("rs13353497", "T");
            hivimmune_pos.Add("rs2280410", "T");
            hivimmune_pos.Add("rs2280411", "G");
            hivimmune_pos.Add("rs6783573", "A");
            hivimmune_pos.Add("rs17287098", "G");
            hivimmune_pos.Add("rs7650998", "T");
            hivimmune_pos.Add("rs3806701", "G");
            hivimmune_pos.Add("rs3806702", "T");
            hivimmune_pos.Add("rs11130097", "T");
            hivimmune_pos.Add("rs2280414", "T");
            hivimmune_pos.Add("rs9860011", "G");
            hivimmune_pos.Add("rs12637699", "C");
            hivimmune_pos.Add("rs17287344", "G");
            hivimmune_pos.Add("rs12490188", "A");
            hivimmune_pos.Add("rs10514714", "G");
            hivimmune_pos.Add("rs9880442", "T");
            hivimmune_pos.Add("rs11713702", "A");
            hivimmune_pos.Add("rs1520492", "A");
            hivimmune_pos.Add("rs1520494", "G");
            hivimmune_pos.Add("rs1520485", "A");
            hivimmune_pos.Add("rs13076522", "G");
            hivimmune_pos.Add("rs6799581", "T");
            hivimmune_pos.Add("rs7640056", "A");
            hivimmune_pos.Add("rs6442009", "G");
            hivimmune_pos.Add("rs2139637", "A");
            hivimmune_pos.Add("rs17079009", "C");
            hivimmune_pos.Add("rs10452028", "T");
            hivimmune_pos.Add("rs873382", "A");
            hivimmune_pos.Add("rs1106665", "T");
            hivimmune_pos.Add("rs869701", "C");
            hivimmune_pos.Add("rs9817414", "C");
            hivimmune_pos.Add("rs9880885", "G");
            hivimmune_pos.Add("rs9829227", "T");
            hivimmune_pos.Add("rs3796369", "A");
            hivimmune_pos.Add("rs1356875", "T");
            hivimmune_pos.Add("rs1520487", "C");
            hivimmune_pos.Add("rs6805749", "C");
            hivimmune_pos.Add("rs1520489", "A");
            hivimmune_pos.Add("rs11130099", "T");
            hivimmune_pos.Add("rs4234464", "G");
            hivimmune_pos.Add("rs11709020", "T");
            hivimmune_pos.Add("rs2385859", "G");
            hivimmune_pos.Add("rs950190", "T");
            hivimmune_pos.Add("rs12491236", "C");
            hivimmune_pos.Add("rs12491294", "G");
            hivimmune_pos.Add("rs7633770", "A");
            hivimmune_pos.Add("rs9861101", "C");
            hivimmune_pos.Add("rs6442013", "T");
            hivimmune_pos.Add("rs6804118", "A");
            hivimmune_pos.Add("rs4519738", "C");
            hivimmune_pos.Add("rs4682826", "G");
            hivimmune_pos.Add("rs3747519", "C");
            hivimmune_pos.Add("rs3747520", "C");
            hivimmune_pos.Add("rs3827495", "C");
            hivimmune_pos.Add("rs11711074", "T");
            hivimmune_pos.Add("rs3210183", "G");
            hivimmune_pos.Add("rs3935248", "C");
            hivimmune_pos.Add("rs7433347", "T");
            hivimmune_pos.Add("rs6806400", "G");
            hivimmune_pos.Add("rs9854487", "G");
            hivimmune_pos.Add("rs9817508", "G");
            hivimmune_pos.Add("rs6442019", "A");
            hivimmune_pos.Add("rs10451990", "G");
            hivimmune_pos.Add("rs6803988", "C");
            hivimmune_pos.Add("rs6795714", "C");
            hivimmune_pos.Add("rs9847407", "T");
            hivimmune_pos.Add("rs7373358", "G");
            hivimmune_pos.Add("rs7633016", "G");
            hivimmune_pos.Add("rs12496585", "G");
            hivimmune_pos.Add("rs4076927", "A");
            hivimmune_pos.Add("rs11718902", "A");
            hivimmune_pos.Add("rs6442020", "T");
            hivimmune_pos.Add("rs9867730", "G");
            hivimmune_pos.Add("rs6442021", "C");
            hivimmune_pos.Add("rs4683316", "G");
            hivimmune_pos.Add("rs7650366", "G");
            hivimmune_pos.Add("rs7426919", "A");
            hivimmune_pos.Add("rs12491225", "A");
            hivimmune_pos.Add("rs7628174", "C");
            hivimmune_pos.Add("rs9814780", "C");
            hivimmune_pos.Add("rs9815362", "C");
            hivimmune_pos.Add("rs35261087", "G");
            hivimmune_pos.Add("rs7632176", "G");
            hivimmune_pos.Add("rs7623501", "C");
            hivimmune_pos.Add("rs7639979", "A");
            hivimmune_pos.Add("rs6808303", "T");
            hivimmune_pos.Add("rs6793661", "C");
            hivimmune_pos.Add("rs6763438", "T");
            hivimmune_pos.Add("rs6801459", "A");
            hivimmune_pos.Add("rs6810260", "T");
            hivimmune_pos.Add("rs4075012", "T");
            hivimmune_pos.Add("rs7614762", "T");
            hivimmune_pos.Add("rs7644977", "G");
            hivimmune_pos.Add("rs6442028", "C");
            hivimmune_pos.Add("rs6764523", "A");
            hivimmune_pos.Add("rs6768252", "C");
            hivimmune_pos.Add("rs7647507", "A");
            hivimmune_pos.Add("rs6796502", "G");
            hivimmune_pos.Add("rs7636089", "A");
            hivimmune_pos.Add("rs12107311", "T");
            hivimmune_pos.Add("rs28493273", "G");
            hivimmune_pos.Add("rs4683304", "C");
            hivimmune_pos.Add("rs6787229", "G");
            hivimmune_pos.Add("rs1077216", "C");
            hivimmune_pos.Add("rs9845430", "G");
            hivimmune_pos.Add("rs6781266", "T");
            hivimmune_pos.Add("rs1042973", "C");
            hivimmune_pos.Add("rs3729704", "G");
            hivimmune_pos.Add("rs1531136", "C");
            hivimmune_pos.Add("rs2227294", "T");
            hivimmune_pos.Add("rs3792557", "C");
            hivimmune_pos.Add("rs3792558", "C");
            hivimmune_pos.Add("rs2233264", "G");
            hivimmune_pos.Add("rs7633581", "C");
            hivimmune_pos.Add("rs6808052", "G");
            hivimmune_pos.Add("rs936173", "C");
            hivimmune_pos.Add("rs6442037", "A");
            hivimmune_pos.Add("rs724450", "G");
            hivimmune_pos.Add("rs1138518", "C");
            hivimmune_pos.Add("rs7652849", "C");
            hivimmune_pos.Add("rs11719795", "C");
            hivimmune_pos.Add("rs12715420", "T");
            hivimmune_pos.Add("rs9855938", "A");
            hivimmune_pos.Add("rs13327489", "G");
            hivimmune_pos.Add("rs2290545", "A");
            hivimmune_pos.Add("rs4683297", "T");
            hivimmune_pos.Add("rs4683295", "G");
            hivimmune_pos.Add("rs4682844", "T");
            hivimmune_pos.Add("rs1466273", "G");
            hivimmune_pos.Add("rs1466272", "T");
            hivimmune_pos.Add("rs13092573", "CT");
            hivimmune_pos.Add("rs2385870", "G");
            hivimmune_pos.Add("rs11130110", "C");
            hivimmune_pos.Add("rs2061197", "C");
            hivimmune_pos.Add("rs2385868", "A");
            hivimmune_pos.Add("rs11709876", "C");
            hivimmune_pos.Add("rs11130112", "T");
            hivimmune_pos.Add("rs749512", "C");
            hivimmune_pos.Add("rs1982510", "A");
            hivimmune_pos.Add("rs11708257", "G");
            hivimmune_pos.Add("rs2290547", "G");
            hivimmune_pos.Add("rs10510752", "C");
            hivimmune_pos.Add("rs7610636", "A");
            hivimmune_pos.Add("rs11917361", "C");
            hivimmune_pos.Add("rs7645448", "A");
            hivimmune_pos.Add("rs4082155", "A");
            hivimmune_pos.Add("rs4078466", "T");
            hivimmune_pos.Add("rs12631730", "T");
            hivimmune_pos.Add("rs13061071", "A");
            hivimmune_pos.Add("rs6767907", "G");

        }

        public byte[] Zip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }

        public byte[] Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return mso.ToArray();
            }
        }

        public void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                hivimmune_match.Clear();
                int hiv_immune = checkHIVImmunity(dialog.FileName, hivimmune_pos, "3");
                if(hiv_immune==RESULT_TRUE)
                {
                    MessageBox.Show("You are almost completely immune to infection by HIV");
                }
                else if (hiv_immune == RESULT_PROB_TRUE)
                {
                    MessageBox.Show("You may be immune to infection by HIV, but I cannot confirm it due to insufficient information in your autosomal file.");
                }
                else if (hiv_immune == RESULT_FALSE)
                {
                    MessageBox.Show("You are not completely immune to infection by HIV");
                }
                else
                {
                    MessageBox.Show("Sorry, your autosomal file does not have enough data to access HIV immunity.");
                }
            }
        }

        private int checkHIVImmunity(string file, Dictionary<string, string> ibd_gt_ref, string chr)
        {
            List<string> match = new List<string>();
            string text = getAutosomalText(file);
            int allowed_errors = ibd_gt_ref.Count * 4 / 100;
            StringReader reader = new StringReader(text);
            string line = null;
            string[] data = null;
            bool is_match = true;
            int error_count = 0;
            //StringBuilder stmp = new StringBuilder();
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("#") || line.StartsWith("RSID") || line.StartsWith("rsid"))
                    continue;
                line = line.Replace("\"", "").Replace("\t", ",");
                data = line.Split(new char[] { ',' });
                if (data.Length == 5)
                    data[3] = data[3] + data[4];

                if (data[3].Length == 1) // for some crazy reason
                    data[3] = data[3] + data[3];
                else if (data[3].Length == 0)
                    continue;

                if (data[1] == chr)
                {
                    //stmp.Append(line);
                    //stmp.Append("\r\n");                    

                    if (ibd_gt_ref.ContainsKey(data[0]))
                    {
                        if (ibd_gt_ref[data[0]].Length == 1)
                        {
                            if (ibd_gt_ref[data[0]] == data[3][0].ToString() || ibd_gt_ref[data[0]] == data[3][1].ToString())
                                match.Add(data[0]);
                            else
                            {
                                if (data[3].IndexOf("-") != -1 || data[3].IndexOf("0") != -1 || data[3].IndexOf("?") != -1)
                                    continue;

                                error_count++;
                                if (error_count >= allowed_errors)
                                {
                                    is_match = false;
                                    break;
                                }
                                else
                                    match.Add(data[0]);
                            }
                        }
                        else if (ibd_gt_ref[data[0]].Length == 2)
                        {
                            if (ibd_gt_ref[data[0]][0].ToString() == data[3][0].ToString() ||
                                ibd_gt_ref[data[0]][0].ToString() == data[3][1].ToString() ||
                                ibd_gt_ref[data[0]][1].ToString() == data[3][0].ToString() ||
                                ibd_gt_ref[data[0]][1].ToString() == data[3][1].ToString())
                                match.Add(data[0]);
                            else
                            {
                                if (data[3].IndexOf("-") != -1 || data[3].IndexOf("0") != -1 || data[3].IndexOf("?") != -1)
                                    continue;

                                error_count++;
                                if (error_count >= allowed_errors)
                                {
                                    is_match = false;
                                    break;
                                }
                                else
                                    match.Add(data[0]);
                            }
                        }
                        else
                        {
                            if (data[3].IndexOf("-") != -1 || data[3].IndexOf("0") != -1 || data[3].IndexOf("?") != -1)
                                continue;

                            error_count++;
                            if (error_count >= allowed_errors)
                            {
                                is_match = false;
                                break;
                            }
                            else
                                match.Add(data[0]);
                        }
                    }
                }
            }

            //File.WriteAllText(@"D:\Temp\" + Path.GetFileName(file) + ".7", stmp.ToString());

            if (is_match)
            {
                if (match.Count >= ibd_gt_ref.Keys.Count * 0.9)
                    return RESULT_TRUE;
                else if (match.Count >= ibd_gt_ref.Keys.Count * 0.5)
                    return RESULT_PROB_TRUE;
                else
                    return RESULT_NA;
            }
            else
            {
                return RESULT_FALSE;
            }
        }

        private string getAutosomalText(string file)
        {
            string text = null;

            if (file.EndsWith(".gz"))
            {
                StringReader reader = new StringReader(Encoding.UTF8.GetString(Unzip(File.ReadAllBytes(file))));
                text = reader.ReadToEnd();
                reader.Close();

            }
            else if (file.EndsWith(".zip"))
            {
                using (var fs = new MemoryStream(File.ReadAllBytes(file)))
                using (var zf = new ZipFile(fs))
                {
                    var ze = zf[0];
                    if (ze == null)
                    {
                        throw new ArgumentException("file not found in Zip");
                    }
                    using (var s = zf.GetInputStream(ze))
                    {
                        using (StreamReader sr = new StreamReader(s))
                        {
                            text = sr.ReadToEnd();
                        }
                    }
                }
            }
            else
                text = File.ReadAllText(file);
            return text;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.y-str.org/");
        }
    }
}

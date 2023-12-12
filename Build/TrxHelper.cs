using System.Xml.Linq;
using Nuke.Common.IO;

class TrxHelper
{

    public TrxHelper(AbsolutePath trxFilepath) {
        TrxFilepath = trxFilepath;
        XElement root = XElement.Load(trxFilepath);

        XElement testSettings = root.Element("{http://microsoft.com/schemas/VisualStudio/TeamTest/2010}TestSettings");
        XElement deployment = testSettings.Element("{http://microsoft.com/schemas/VisualStudio/TeamTest/2010}Deployment");
        string deploymentRoot = deployment.FirstAttribute.Value;

        XElement resultSummary = root.Element("{http://microsoft.com/schemas/VisualStudio/TeamTest/2010}ResultSummary");
        XElement cde = resultSummary.Element("{http://microsoft.com/schemas/VisualStudio/TeamTest/2010}CollectorDataEntries");
        XElement collector = cde.Element("{http://microsoft.com/schemas/VisualStudio/TeamTest/2010}Collector");
        string computerName = collector.Attribute("agentName").Value;

        CoverageSource = trxFilepath.Parent / deploymentRoot / "In" / computerName / "coverage.cobertura.xml";
        CoverageDestination = (RelativePath)(trxFilepath.NameWithoutExtension + ".cobertura.xml");
    }

    public RelativePath CoverageDestination { get; }

    public AbsolutePath CoverageSource { get; }

    public AbsolutePath TrxFilepath { get; }

}
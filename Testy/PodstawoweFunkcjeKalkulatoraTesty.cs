using KalkulatorFunkcje;
using NUnit.Framework.Internal;

namespace Testy;

public class Tests
{
    [TestFixture]
    public class PodstawoweFunkcjeTest
    {
        [Test]
        public void DodawanieZera()
        {
            Assert.That(0, Is.EqualTo(PodstawoweFunkcje.Dodawanie(0, 0)));
        }
        [Test]
        public void DodawanieUjemnych()
        {
            Assert.That(-2, Is.EqualTo(PodstawoweFunkcje.Dodawanie(-2, 0)));
        }
        [Test]
        public void DodawanieDodatnie()
        {
            Assert.That(2, Is.EqualTo(PodstawoweFunkcje.Dodawanie(1, 1)));
        }
        [Test]
        public void OdejmowanieZera()
        {
            Assert.That(0, Is.EqualTo(PodstawoweFunkcje.Odejmowanie(0, 0)));
        }
        [Test]
        public void OdejmowanieUjemnych()
        {
            Assert.That(2, Is.EqualTo(PodstawoweFunkcje.Odejmowanie(-2, -4)));
        }
        [Test]
        public void OdejmowanieDodatnie()
        {
            Assert.That(0, Is.EqualTo(PodstawoweFunkcje.Odejmowanie(1, 1)));

        }
        [Test]
        public void MnozenieZera()
        {
            Assert.That(0, Is.EqualTo(PodstawoweFunkcje.Mnozenie(0, 0)));
        }
        [Test]
        public void MnozenieUjemnych()
        {
            Assert.That(8, Is.EqualTo(PodstawoweFunkcje.Mnozenie(-2, -4)));
        }
        [Test]
        public void MnozenieDodatnie()
        {
            Assert.That(1, Is.EqualTo(PodstawoweFunkcje.Mnozenie(1, 1)));

        }
        [Test]
        public void DzielenieZera()
        {
            Assert.Throws(Is.TypeOf<Exception>()
                    .And.Message.EqualTo("Nie można dzielić przez zero"), 
                () => PodstawoweFunkcje.Dzielenie(0,0));
        }
        [Test]
        public void DzielenieUjemnych()
        {
            Assert.That(0, Is.EqualTo(PodstawoweFunkcje.Dzielenie(-2, -4)));
        }
        [Test]
        public void DzielenieDodatnie()
        {
            Assert.That(1, Is.EqualTo(PodstawoweFunkcje.Dzielenie(1, 1)));

        }
        [Test]
        public void DzielenieModuloZera()
        {
            Assert.Throws(Is.TypeOf<Exception>()
                    .And.Message.EqualTo("Nie można dzielić przez zero"), 
                () => PodstawoweFunkcje.DzielenieModulo(0,0));
        }
        [Test]
        public void DzielenieModuloUjemnych()
        {
            Assert.That(-2, Is.EqualTo(PodstawoweFunkcje.DzielenieModulo(-2, -4)));
        }
        [Test]
        public void DzielenieModuloDodatnie()
        {
            Assert.That(0, Is.EqualTo(PodstawoweFunkcje.DzielenieModulo(1, 1)));

        }
    }
}
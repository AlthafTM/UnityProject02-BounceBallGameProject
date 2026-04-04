using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Level1() { LoadLevel(1); }
    public void Level2() { LoadLevel(2); }
    public void Level3() { LoadLevel(3); }
    public void Level4() { LoadLevel(4); }
    public void Level5() { LoadLevel(5); }
    public void Level6() { LoadLevel(6); }
    public void Level7() { LoadLevel(7); }
    public void Level8() { LoadLevel(8); }
    public void Level9() { LoadLevel(9); }
    public void Level10() { LoadLevel(10); }
    public void Level11() { LoadLevel(11); }
    public void Level12() { LoadLevel(12); }
    public void Level13() { LoadLevel(13); }
    public void Level14() { LoadLevel(14); }
    public void Level15() { LoadLevel(15); }
    public void Level16() { LoadLevel(16); }
    public void Level17() { LoadLevel(17); }
    public void Level18() { LoadLevel(18); }
    public void Level19() { LoadLevel(19); }
    public void Level20() { LoadLevel(20); }
    public void Level21() { LoadLevel(21); }
    public void Level22() { LoadLevel(22); }
    public void Level23() { LoadLevel(23); }
    public void Level24() { LoadLevel(24); }
    public void Level25() { LoadLevel(25); }
    public void Level26() { LoadLevel(26); }
    public void Level27() { LoadLevel(27); }
    public void Level28() { LoadLevel(28); }
    public void Level29() { LoadLevel(29); }
    public void Level30() { LoadLevel(30); }
    public void Level31() { LoadLevel(31); }
    public void Level32() { LoadLevel(32); }
    public void Level33() { LoadLevel(33); }
    public void Level34() { LoadLevel(34); }
    public void Level35() { LoadLevel(35); }
    public void Level36() { LoadLevel(36); }
    public void Level37() { LoadLevel(37); }
    public void Level38() { LoadLevel(38); }
    public void Level39() { LoadLevel(39); }
    public void Level40() { LoadLevel(40); }
    public void Level41() { LoadLevel(41); }
    public void Level42() { LoadLevel(42); }
    public void Level43() { LoadLevel(43); }
    public void Level44() { LoadLevel(44); }
    public void Level45() { LoadLevel(45); }
    public void Level46() { LoadLevel(46); }
    public void Level47() { LoadLevel(47); }
    public void Level48() { LoadLevel(48); }
    public void Level49() { LoadLevel(49); }
    public void Level50() { LoadLevel(50); }
    public void Level51() { LoadLevel(51); }
    public void Level52() { LoadLevel(52); }
    public void Level53() { LoadLevel(53); }
    public void Level54() { LoadLevel(54); }
    public void Level55() { LoadLevel(55); }
    public void Level56() { LoadLevel(56); }
    public void Level57() { LoadLevel(57); }
    public void Level58() { LoadLevel(58); }
    public void Level59() { LoadLevel(59); }
    public void Level60() { LoadLevel(60); }
    public void Level61() { LoadLevel(61); }
    public void Level62() { LoadLevel(62); }
    public void Level63() { LoadLevel(63); }
    public void Level64() { LoadLevel(64); }
    public void Level65() { LoadLevel(65); }
    public void Level66() { LoadLevel(66); }
    public void Level67() { LoadLevel(67); }
    public void Level68() { LoadLevel(68); }
    public void Level69() { LoadLevel(69); }
    public void Level70() { LoadLevel(70); }
    public void Level71() { LoadLevel(71); }
    public void Level72() { LoadLevel(72); }
    public void Level73() { LoadLevel(73); }
    public void Level74() { LoadLevel(74); }
    public void Level75() { LoadLevel(75); }
    public void Level76() { LoadLevel(76); }
    public void Level77() { LoadLevel(77); }
    public void Level78() { LoadLevel(78); }
    public void Level79() { LoadLevel(79); }
    public void Level80() { LoadLevel(80); }
    public void Level81() { LoadLevel(81); }
    public void Level82() { LoadLevel(82); }
    public void Level83() { LoadLevel(83); }
    public void Level84() { LoadLevel(84); }
    public void Level85() { LoadLevel(85); }
    public void Level86() { LoadLevel(86); }
    public void Level87() { LoadLevel(87); }
    public void Level88() { LoadLevel(88); }
    public void Level89() { LoadLevel(89); }
    public void Level90() { LoadLevel(90); }
    public void Level91() { LoadLevel(91); }
    public void Level92() { LoadLevel(92); }
    public void Level93() { LoadLevel(93); }
    public void Level94() { LoadLevel(94); }
    public void Level95() { LoadLevel(95); }
    public void Level96() { LoadLevel(96); }
    public void Level97() { LoadLevel(97); }
    public void Level98() { LoadLevel(98); }
    public void Level99() { LoadLevel(99); }
    public void Level100() { LoadLevel(100); }

    private void LoadLevel(int level)
    {
        SceneManager.LoadSceneAsync(level);
        SceneController.CurrentLevel = level;
    }
}

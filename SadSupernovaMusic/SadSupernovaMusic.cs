using OWML.ModHelper;

namespace SadSupernovaMusic;
public class Mod : ModBehaviour
{    
    private void Start()
    {
        LoadManager.OnCompleteSceneLoad += (_, _) =>
        {
            var newMusic = ModHelper.Assets.GetAudio("snowfall.mp3");            

            ModHelper.Events.Unity.FireInNUpdates(() =>
            {
                var audioTable = Locator.GetAudioManager()._audioLibraryDict;
                audioTable[(int)AudioType.EndOfTime] = new AudioLibrary.AudioEntry(AudioType.EndOfTime, new[] { newMusic });

                ModHelper.Console.WriteLine("Sad supernova now!");

            }, 10);          
           
        };
    }
}
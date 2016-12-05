using UnityEngine;

public class StarParticleCreator : MonoBehaviour
{
    public ParticleSystem myParticleSystem;
    public int maxParticles = 2000;
    public TextAsset starCSV;

    void Awake()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
        myParticleSystem.maxParticles = maxParticles;
        ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[1];
        bursts[0].minCount = (short)maxParticles;
        bursts[0].maxCount = (short)maxParticles;
        bursts[0].time = 0.0f;
        myParticleSystem.emission.SetBursts(bursts, 1);
    }

    void Start()
    {
        string[] lines = starCSV.text.Split('\n');

        ParticleSystem.Particle[] particleStars = new ParticleSystem.Particle[maxParticles];
        myParticleSystem.GetParticles(particleStars);

        for (int i = 0; i < maxParticles; i++)
        {
            string[] components = lines[i].Split(';');
            particleStars[i].position = new Vector3(float.Parse(components[1]),
                                                    float.Parse(components[3]),
                                                    float.Parse(components[2])).normalized * Camera.main.farClipPlane * 0.9f;
            particleStars[i].lifetime = Mathf.Infinity;
            particleStars[i].startColor = Color.white * (1.0f - ((float.Parse(components[0]) + 1.44f) / 8));
        }

        myParticleSystem.SetParticles(particleStars, maxParticles);
    }
}

using TMPro;
using UnityEngine;

public class PontuacaoGUIScript : MonoBehaviour
{
    [Header("Pontuacao do Jogo")]
    [SerializeField]
    int pontuacao;
    [SerializeField]
    int pontuacaoMaxima;
    [SerializeField]
    TextMeshProUGUI textoPontuacao;
    [SerializeField]
    TextMeshProUGUI textoPontuacaoMaxima;
    void Start()
    {
        textoPontuacao.SetText(pontuacao.ToString());
        pontuacaoMaxima = PlayerPrefs.GetInt("pontuacaoMaxima", pontuacaoMaxima);
        textoPontuacaoMaxima.SetText(pontuacaoMaxima.ToString());
    }

    public void AdicionarPonto()
    {
        pontuacao++;
        textoPontuacao.SetText(pontuacao.ToString());
        if (pontuacao > pontuacaoMaxima)
        {
            pontuacaoMaxima = pontuacao;
            textoPontuacaoMaxima.SetText(pontuacaoMaxima.ToString());
            PlayerPrefs.SetInt("pontuacaoMaxima", pontuacaoMaxima);
            pontuacaoMaxima = PlayerPrefs.GetInt("pontuacaoMaxima", pontuacaoMaxima);
            textoPontuacaoMaxima.SetText(pontuacaoMaxima.ToString());
        }

    }
}

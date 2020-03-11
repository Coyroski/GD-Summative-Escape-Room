using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookController : MonoBehaviour
{
    public GameObject BookRight;
    public GameObject BookRightOpen;
    public GameObject BookWrong;
    public GameObject BookWrong2;
    public GameObject BookWrong3;
    public GameObject BookWrong4;
    public GameObject BookWrong5;
    public GameObject BookWrong6;
    public GameObject BookWrong7;
    public static bool GotBookKey = false;
    public GameObject Menu;
    public AudioSource booksound;

    private void Update()
    {
        if (BookInteractionOpenRight.rightbookclosed == true)
        {
            Menu.SetActive(true);
            BookInteractionOpenRight.rightbookclosed = false;
        }
        if (BookInteractionWrong2.wrong2closed == true)
        {
            Menu.SetActive(true);
            BookInteractionWrong2.wrong2closed = false;
        }
        if (BookInteractionWrong3.wrong3closed == true)
        {
            Menu.SetActive(true); 
            BookInteractionWrong3.wrong3closed = false;
        }
        if (BookInteractionWrong6.wrong6closed == true)
        {
            Menu.SetActive(true);
            BookInteractionWrong6.wrong6closed = false;
        }
        if (BookInteractionWrong.wrongclosed == true)
        {
            Menu.SetActive(true);
            BookInteractionWrong.wrongclosed = false;
        }
        if (BookInteractionWrong4.wrong4closed == true)
        {
            Menu.SetActive(true);
            BookInteractionWrong4.wrong4closed = false;
        }
        if (BookInteractionWrong5.wrong5closed == true)
        {
            Menu.SetActive(true); 
            BookInteractionWrong5.wrong5closed = false;
        }
    }
    public void RightBookPressed()
    {
        Instantiate(BookRight, new Vector3(0f, 0f, 0f), Quaternion.identity);
        GotBookKey = true;
        Debug.Log("LOOK THERE IS A KEY!");
        booksound.Play();

        Menu.SetActive(false);
    }

    public void WrongBookPressed_1()
    {
        Instantiate(BookWrong, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Debug.Log("This is a book about moths.");
        booksound.Play();
        Menu.SetActive(false);
    }

    public void WrongBookPressed_2()
    {
        Instantiate(BookWrong2, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Debug.Log("This is a book about door knobs.");
        booksound.Play();
        Menu.SetActive(false);
    }

    public void WrongBookPressed_3()
    {
        Instantiate(BookWrong3, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Debug.Log("This is a book about door knobs.");
        booksound.Play();
        Menu.SetActive(false);
    }

    public void WrongBookPressed_4()
    {
        Instantiate(BookWrong4, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Debug.Log("This is a book about door knobs.");
        booksound.Play();
        Menu.SetActive(false);
    }

    public void WrongBookPressed_5()
    {
        Instantiate(BookWrong5, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Debug.Log("This is a book about door knobs.");
        booksound.Play();
        Menu.SetActive(false);
    }

    public void WrongBookPressed_6()
    {
        Instantiate(BookWrong6, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Debug.Log("This is a book about door knobs.");
        booksound.Play();
        Menu.SetActive(false);
    }

    public void WrongBookPressed_7()
    {
        Instantiate(BookWrong7, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Debug.Log("This is a book about door knobs.");
        booksound.Play();
        Menu.SetActive(false);
    }
    public void ExitPressed()
    {
        SceneManager.LoadScene("Level");
    }
}

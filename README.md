# Metronome

## 개요

비프음을 활용하여 메트로놈을 만들어보았다.

메트로놈의 기본적인 ui를 구성하고자 winform을 사용하였고
이에따라 언어는 C#을 이용하였다.



## 사용함수

C#에서 비프음 출력은 C와 크게 다르지 않다.
아래는 C#에서의 비프음 출력 함수이다.
~~~C#
Console.Beep(880,100);
~~~
매개변수 역시 C와 다르지 않다.
<br><br><br>


## 메커니즘

기본적인 메커니즘은 아래와 같다.

시작버튼 클릭 -> 비프출력쓰레드 시작-> 종료버튼 클릭 -> 비프출력쓰레드 종료

위의 메커니즘을 반복하면서 프로그램이 동작한다.
<br><br><br>


## 소스

### 사운드 출력

이 메트로놈은 기본적으로 4분의 4박자를 전제로 만들었다.

그렇기 때문에 사운드 출력을 아래와 같이 해주었다.
~~~C#
while (true)
{
    Console.Beep(880, 100);
    Thread.Sleep((int)args);
    Console.Beep(440, 100);
    Thread.Sleep((int)args);
    Console.Beep(440, 100);
    Thread.Sleep((int)args);
    Console.Beep(440, 100);
    Thread.Sleep((int)args);
}
~~~

4개의 비프음이 차례로 출력이 된다. 

다만 하나의 음이 출력되고 나서 다음 음이 출력되기 까지 시간을 조절해주는 식으로 bom에 따른 소리출력을 다르게 해주었다.

또한 첫번째 박자는 880hz로 설정해주어 첫번째 박자를 구분할 수 있게 만들어 주었다.
<br><br><br><br>



### 시작버튼 클릭
~~~C#
if (String.IsNullOrEmpty(txt_BPM.Text) || Convert.ToInt32(txt_BPM.Text) <= 0 )
        MessageBox.Show("Please input valid text", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
else if(Convert.ToInt32(txt_BPM.Text) > 360)
{
        MessageBox.Show("Max BPM is 360", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
else 
{
        btn_end.Visible = true;
        btn_start.Visible = false;
        thread = new Thread(new ParameterizedThreadStart(SoundPlay));
        bpm = Convert.ToInt32(txt_BPM.Text);
        int Duration = 1000 * 60 / bpm - 100;
        thread.Start(Duration);
}
~~~
일단 기본적으로 텍스트 입력란에 hz에 대한 숫자를 입력받는다.<br>
여기서 0보다 작을때와 아무것도 입력하지 않았을 때에 대한 예외처리를 해주었다.<br><br>

그 다음으로 최대 hz를 360으로 설정해 주었다.<br>
왜냐하면 그 이상 hz를 올리게 되면 중간에 비프음이 겹치거나 생략이 되는 일이 발생했기 때문이다.<br><br>

다음으로 시작버튼이 눌리면 시작버튼을 안보이게 설정하고 종료버튼을 보이게 설정해 주었다.<br>
이런 식으로 만들어서 시작버튼이 눌리면 시작버튼이 없어지고 종료버튼이 생기게끔 만들어 주었다.<br><br>

시작 버튼이 눌리면 thread가 생성 및 실행이 되고 bpm이 매개변수로 전달이 되는데 <br>
이 매개변수를 duration변수로 설정해 주었다.<br>
일단 기본적으로 메트로놈에서 60hz가 의미하는 바를 1분에 60번 음이 출력된다는 것이다.<br>
즉, 1초에 한번씩 음이 출력된다는 것이다.<br>
그리고 여기서 hz가 올라감에 따라 빨라지고 hz가 내려감에 따라 느려진다.<br>
이것을 식으로 표현해 주었다.
~~~C#
1000 * 60 / bpm - 100
~~~
이것으로 duration에 대한 값을 구했다.
<br><br><br><br>



### 나머지

마지막으로는 종료버튼이 눌렸을 때 쓰레드를 종료시키는 것과 텍스트박스에 대한 예외처리를 해주었다.

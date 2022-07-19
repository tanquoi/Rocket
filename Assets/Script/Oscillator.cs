using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// oscillate is something in your level so that it provides an interesting challenge for your player
//dao động là thứ gì đó trong cấp độ của bạn để nó cung cấp một thử thách thú vị cho người chơi của bạn
public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float peroid = 2f;
  
    void Start()
    {
        startingPosition = transform.position;

    }
    // ghi chú về điều kiến so sánh float
    // hai biến float có thể khác nhau một lượng nhỏ
    // không thể đoán trước khi sử dụng == với float
    // luôn chỉ rõ sự khác biệt có thể chấp nhận được
    // float nhỏ nhất là Mathf.Epsilon
    // luôn so sánh với điều này hơn là 0

    // ví dụ if(peroid <= 0) { return; }
    void Update()
    {
        MovementGameObject();
    }

    public void MovementGameObject()
    {
        if (peroid <= Mathf.Epsilon) { return; }
        float cycles = Time.time / peroid; //liên tục phát triển theo thời gian

        const float tau = Mathf.PI * 2; //giá trị không đổi là 6,283
        float rawSinWave = Mathf.Sin(cycles * tau); //đi từ -1 đến 1

        movementFactor = (rawSinWave + 1f) / 2f; //được tính toán lại để đi từ 0 đến 1 sao cho gọn hơn

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }

    //Cách tiếp cận thiết kế trò chơi hữu ích

    // Thiết kế "khoảnh khắc" và sau đó mở rộng chúng thành một cấp độ.Những khoảnh khắc sử dụng môi trường:
    // bay dưới
    // cầu vượt
    // bay qua chướng ngại vật di chuyển
    // hạ cánh trên nền tảng di chuyển
    // bay qua đường hầm hẹp

    //vi du: những khoảnh khắc sử dụng điều chỉnh trong trò chơi của mình là: 
    //tên lửa chậm, tên lửa nhanh, cảnh quang tối, camera gần hơn, điều khiển đảo ngược (reversed control)


    // thiết kế thử thách cho người chơi
    // tạo từ 5 hoặc nhiều hơn độ khó level khác nhau. với mỗi cảnh độc đáo
}

#ifndef CAMERA_H
#define CAMERA_H

#include <glad/glad.h>
#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>

#include <vector>

enum camerMovement {
	FORWARD,
	BACKWARD,
	LEFT,
	RIGHT
};
class Camera {
public:
	glm::vec3 pos;
	glm::vec3 lookAt;
	glm::vec3 dir;
	glm::vec3 up;
	glm::vec3 right;
	glm::vec3 worldUp;


	float yaw;
	float pitch;
	float movementSpeed;
	float mouseSensitivity;
	float fov;

	Camera(glm::vec3 postion = glm::vec3(0.0f, 0.0f, 5.0f), glm::vec3 lookAt=glm::vec3(0.0f,0.0f,0.0f),
		glm::vec3 worldUp=glm::vec3(0.0f,1.0f,0.0f),float yaw = -90.0f, float pitch = 0.0f,
		float movementSpeed=2.5f,float mouseSensitivity=0.05f,float fov=45.0f):pos(postion),
		lookAt(lookAt),worldUp(worldUp),yaw(yaw),pitch(pitch),movementSpeed(movementSpeed),
		mouseSensitivity(mouseSensitivity),fov(fov){
			dir = glm::normalize(lookAt - pos);
			right = glm::normalize(glm::cross(dir, worldUp));
			up = glm::normalize(glm::cross(right, dir));
		}
	glm::mat4 GetViewMatrix()
	{
		return glm::lookAt(pos, pos + dir, up);
	}
	
	void ProcessKeyboard(camerMovement direction, float deletaTime) {
		float vel = deletaTime * movementSpeed;
		if (direction == FORWARD)
			pos += dir * vel;
		if (direction == BACKWARD)
			pos -= dir * vel;
		if (direction == LEFT)
			pos -= right * vel;
		if (direction == RIGHT)
			pos += right * vel;
	}
	void ProcessMouseMovement(float xoffset, float yoffset, GLboolean constrainPitch = true)
	{
		xoffset *= mouseSensitivity;
		yoffset *= mouseSensitivity;

		yaw += xoffset;
		pitch += yoffset;

		if (constrainPitch)
		{
			if (pitch > 89.0f)
				pitch = 89.0f;
			if (pitch < -89.0f)
				pitch = -89.0f;
		}

		glm::vec3 front;
		front.x = cos(glm::radians(yaw)) * cos(glm::radians(pitch));
		front.y = sin(glm::radians(pitch));
		front.z = sin(glm::radians(yaw)) * cos(glm::radians(pitch));
		dir = glm::normalize(front);
		right = glm::normalize(glm::cross(dir,worldUp));
		up = glm::normalize(glm::cross( right,dir));
	}
	void ProcessMouseScroll(float yoffset)
	{
		fov -= (float)yoffset;
		if (fov < 1.0f)
			fov = 1.0f;
		if (fov > 45.0f)
			fov = 45.0f;
	}
};

#endif
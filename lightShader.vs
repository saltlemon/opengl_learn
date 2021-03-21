#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec2 aTexCoords;

uniform mat4 view;
uniform mat4 projection;
uniform mat4 transform;
out vec2 texCoords;
void main()
{
    gl_Position = projection*view*transform*vec4(aPos, 1.0);
	texCoords=aTexCoords;
}
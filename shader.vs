#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;
layout (location = 2) in vec2 aTexCoords;

uniform mat4 view;
uniform mat4 projection;
uniform mat4 transform;

out vec3 normal;
out vec3 worldPos;
out vec2 texCoords;
void main()
{
    gl_Position = projection*view*transform*vec4(aPos, 1.0);
	normal=mat3(transpose(inverse(transform))) * aNormal;
	worldPos=vec3(transform*vec4(aPos, 1.0));
	texCoords=aTexCoords;
}
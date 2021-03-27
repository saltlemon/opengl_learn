#version 330 core
layout (location = 0) in vec3 aPos;
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes

layout (location = 2) in vec2 aTexCoords;
layout (location = 3) in mat4 transform;
uniform mat4 view;
uniform mat4 projection;
<<<<<<< Updated upstream
uniform mat4 transform;
void main()
{
    gl_Position = projection*view*transform*vec4(aPos, 1.0);
=======


out vec2 texCoords;
void main()
{
    gl_Position = projection*view*transform*vec4(aPos, 1.0);
	texCoords=aTexCoords;
>>>>>>> Stashed changes
}
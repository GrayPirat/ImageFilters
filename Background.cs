﻿using Agario.Graphics;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;


namespace Agario
{
    // Класс для создания и управления фоном в игре
    internal class BackGround
    {
        // Списки для хранения вершин, текстурных координат и индексов
        public List<Vector3> gameVerts;
        public List<Vector2> gameGraphic = new List<Vector2>();
        public List<uint> gameInd;

        // Объекты для работы с OpenGL: VAO, VBO, IBO и текстура
        VAO gameVAO;
        VBO gameVertexVBO;
        VBO gameGraphicVBO;
        IBO gameIBO;

        Texture texture;

        // Конструктор, который создает куб и загружает текстуру
        public BackGround()
        {
            MakeCube();
            BuildObject("back.jpg");
        }

        // Метод для создания вершин и текстурных координат куба
        public void MakeCube()
        {
            gameVerts = new List<Vector3>()
            {
            new Vector3(-30f, 30f, -30f),
            new Vector3(30f, 30f, -30f),
            new Vector3(30f, -30f, -30f),
            new Vector3(-30f, -30f, -30f),

            new Vector3(30f, 30f, -30f),
            new Vector3(30f, 30f, -30f),
            new Vector3(30f, -30f, -30f),
            new Vector3(30f, -30f, -30f),

            new Vector3(30f, 30f, -30f),
            new Vector3(-30f, 30f, -30f),
            new Vector3(-30f, -30f, -30f),
            new Vector3(30f, -30f, -30f),

            new Vector3(-30f, 30f, -30f),
            new Vector3(-30f, 30f, -30f),
            new Vector3(-30f, -30f, -30f),
            new Vector3(-30f, -30f, -30f),

            new Vector3(-30f, 30f, -30f),
            new Vector3(30f, 30f, -30f),
            new Vector3(30f, 30f, -30f),
            new Vector3(-30f, 30f, -30f),

            new Vector3(-30f, -30f, -30f),
            new Vector3(30f, -30f, -30f),
            new Vector3(30f, -30f, -30f),
            new Vector3(-30f, -30f, -30f),
            };

            // Список текстурных координат для каждой вершины
            gameGraphic = new List<Vector2>()
            {
             new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),

            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),

            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),

            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),

            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),

            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),
            };

            gameInd = new List<uint>{
            0, 1, 2,
            2, 3, 0,

            4, 5, 6,
            6, 7, 4,

            8, 9, 10,
            10, 11, 8,

            12, 13, 14,
            14, 15, 12,

            16, 17, 18,
            18, 19, 16,

            20, 21, 22,
            22, 23, 20
            };
        }
        // Метод для построения объекта: связывает вершинные и текстурные VBO, IBO и загружает текстуру
        public void BuildObject(String path)
        {
            gameVAO = new VAO();
            gameVAO.Bind();

            gameVertexVBO = new VBO(gameVerts);
            gameVertexVBO.Bind();
            gameVAO.LinkToVAO(0, 3, gameVertexVBO);

            gameGraphicVBO = new VBO(gameGraphic);
            gameGraphicVBO.Bind();
            gameVAO.LinkToVAO(1, 2, gameGraphicVBO);

            gameIBO = new IBO(gameInd);

            texture = new Texture(path);
        }
        // Метод для отрисовки объекта с использованием шейдерной программы
        public void Render(ShaderProgram program)
        {
            program.Bind();
            gameVAO.Bind();
            gameIBO.Bind();
            texture.Bind();
            GL.DrawElements(PrimitiveType.Triangles, gameInd.Count, DrawElementsType.UnsignedInt, 0);
        }
        // Метод для удаления всех OpenGL объектов
        public void Delete()
        {
            gameVAO.Delete();
            gameVertexVBO.Delete();
            gameGraphicVBO.Delete();
            gameIBO.Delete();
            texture.Delete();
        }

    }
}
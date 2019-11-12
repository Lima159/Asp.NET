namespace PortalBiblioteca.Utils.Urls
{
    public class UrlApi
    {
        private static string BASE
        {
            get { return @"https://localhost:44370/"; }
        }

        public struct Api
        {
            public struct Autor
            {
                private static string controllerName = "autor";
                private static string version = "v1";
                private static string localName = controllerName + '/' + version;
                private static string partialPath = BASE + "api/" + localName;

                public static string ListarAutores
                {
                    get { return partialPath + ""; }
                }

                public static string ListarAutor
                {
                    get { return partialPath + "/"; }
                }

                public static string EnviarAutor
                {
                    get { return partialPath + ""; }
                }

                public static string AtualizarAutor
                {
                    get { return partialPath + ""; }
                }

                public static string DeletarAutor
                {
                    get { return partialPath + "/"; }
                }
            }

            public struct Editora
            {
                private static string controllerName = "editora";
                private static string version = "v1";
                private static string localName = controllerName + "/" + version;
                private static string partialPath = BASE + "api/" + localName;

                public static string ListarEditoras
                {
                    get { return partialPath + ""; }
                }

                public static string ListarEditora
                {
                    get { return partialPath + "/"; }
                }

                public static string EnviarEditora
                {
                    get { return partialPath + ""; }
                }

                public static string AtualizarEditora
                {
                    get { return partialPath + ""; }
                }

                public static string DeletarEditora
                {
                    get { return partialPath + "/"; }
                }
            }

            public struct Genero
            {
                private static string controllerName = "genero";
                private static string version = "v1";
                private static string localName = controllerName + "/" + version;
                private static string partialPath = BASE + "api/" + localName;

                public static string ListarGeneros
                {
                    get { return partialPath + ""; }
                }

                public static string ListarGenero
                {
                    get { return partialPath + "/"; }
                }

                public static string EnviarGenero
                {
                    get { return partialPath + ""; }
                }

                public static string AtualizarGenero
                {
                    get { return partialPath + ""; }
                }

                public static string DeletarGenero
                {
                    get { return partialPath + "/"; }
                }
            }

            public struct Leitor
            {
                private static string controllerName = "leitor";
                private static string version = "v1";
                private static string localName = controllerName + "/" + version;
                private static string partialPath = BASE + "api/" + localName;

                public static string ListarLeitores
                {
                    get { return partialPath + ""; }
                }

                public static string ListarLeitor
                {
                    get { return partialPath + "/"; }
                }

                public static string EnviarLeitor
                {
                    get { return partialPath + ""; }
                }

                public static string AtualizarLeitor
                {
                    get { return partialPath + ""; }
                }

                public static string DeletarLeitor
                {
                    get { return partialPath + "/"; }
                }
            }

            public struct Livro
            {
                private static string controllerName = "livro";
                private static string version = "v1";
                private static string localName = controllerName + "/" + version;
                private static string partialPath = BASE + "api/" + localName;

                public static string ListarLivros
                {
                    get { return partialPath + ""; }
                }

                public static string ListarLivro
                {
                    get { return partialPath + "/"; }
                }

                public static string EnviarLivro
                {
                    get { return partialPath + ""; }
                }

                public static string AtualizarLivro
                {
                    get { return partialPath + ""; }
                }

                public static string DeletarLivro
                {
                    get { return partialPath + "/"; }
                }
            }

            public struct Emprestimo
            {
                private static string controllerName = "emprestimo";
                private static string version = "v1";
                private static string localName = controllerName + "/" + version;
                private static string partialPath = BASE + "api/" + localName;

                public static string ListarEmprestimos
                {
                    get { return partialPath + "/emprestimos/"; }
                }

                public static string ListarEmprestimo
                {
                    get { return partialPath + "/emprestimo/"; }
                }

                public static string EnviarEmprestimo
                {
                    get { return partialPath + ""; }
                }

                public static string AtualizarEmprestimo
                {
                    get { return partialPath + ""; }
                }

                public static string DeletarEmprestimo
                {
                    get { return partialPath + "/"; }
                }
            }
        }
    }
}

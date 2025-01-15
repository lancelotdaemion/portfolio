namespace Portfolio.Wpf.LoremIpsum
{
    public class Collection
    {
        public static readonly List<PortfolioWpf.Model.LoremIpsum> Values = new List<PortfolioWpf.Model.LoremIpsum> {
            new(){ Id = Guid.NewGuid(), Name = "Nam laoreet lectus eu pharetra dignissim." },
            new(){ Id = Guid.NewGuid(), Name = "Suspendisse aliquet metus at lectus sagittis, ut dictum mi convallis." },
            new(){ Id = Guid.NewGuid(), Name = "Ut sed nibh vel metus porttitor pretium nec sollicitudin orci." },
            new(){ Id = Guid.NewGuid(), Name = "Proin cursus purus eget lorem tempus, in auctor metus malesuada." },
            new(){ Id = Guid.NewGuid(), Name = "Phasellus eu elit sed leo mattis lacinia." },
            new(){ Id = Guid.NewGuid(), Name = "Integer placerat dui vel lacus suscipit placerat." },
            new(){ Id = Guid.NewGuid(), Name = "Sed in libero et ligula maximus pulvinar vitae sed neque." },
            new(){ Id = Guid.NewGuid(), Name = "Pellentesque varius lorem nec auctor auctor." }
        };
    }
}
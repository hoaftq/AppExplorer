namespace Service.Dtos
{

    public class AppDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string ImagePath { get; set; }
    }

}

// export interface AppDto {
//     id: number;
//     name: string;
//     shortDescription: string;
//     imagePath?: string;
// }

// export interface AppDetailsDto {
//     id: number;
//     name: string;
//     shortDescription: string;
//     description: string;
//     imagePath?: string;
//     languages: LanguageDto[];
//     level: number;
//     url?: string;
//     sourceUrl: string;
//     createdDate: Date;
//     updatedDate: Date;

//     categoryId: number;
//     categoryName: string;
// }

// export interface CategoryDto {
//     id: number;
//     name: string;
// }

// export interface LanguageDto {
//     id: number;
//     name: string;
// }
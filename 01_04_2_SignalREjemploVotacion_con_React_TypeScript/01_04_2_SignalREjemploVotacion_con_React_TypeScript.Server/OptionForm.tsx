import { Button } from "@/components/ui/button"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"

export default function Component() {
  const options = [
    { name: "Documentation", url: "https://docs.example.com" },
    { name: "API Reference", url: "https://api.example.com" },
    { name: "Tutorials", url: "https://tutorials.example.com" },
    { name: "Community Forum", url: "https://forum.example.com" },
    { name: "Support", url: "https://support.example.com" },
  ]

  const handleButtonClick = (url: string) => {
    window.open(url, "_blank", "noopener,noreferrer")
  }

  return (
    <Card className="w-full max-w-md mx-auto">
      <CardHeader>
        <CardTitle>Resource Options</CardTitle>
        <CardDescription>Select a resource to visit</CardDescription>
      </CardHeader>
      <CardContent>
        <form className="space-y-4">
          {options.map((option, index) => (
            <div key={index} className="flex items-center justify-between">
              <span className="text-sm font-medium">{option.name}</span>
              <Button
                type="button"
                onClick={() => handleButtonClick(option.url)}
                aria-label={`Visit ${option.name}`}
              >
                Visit
              </Button>
            </div>
          ))}
        </form>
      </CardContent>
    </Card>
  )
}